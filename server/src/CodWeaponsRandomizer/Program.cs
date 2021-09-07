using CodWeaponsRandomizer;
using CodWeaponsRandomizer.Core.COD.Cw;
using CodWeaponsRandomizer.Core.COD.Mw;
using CodWeaponsRandomizer.Core.COD.Wz;
using CodWeaponsRandomizer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

const string MwDbFolderPath = @".\mw";
const string CwDbFolderPath = @".\cw";

const string CorsPolicyName = "RND_COD_LDT";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(MwDb), new MwDb(MwDbFolderPath));
builder.Services.AddSingleton(typeof(CwDb), new CwDb(CwDbFolderPath));

builder.Services.AddTransient<MwLoadoutRandomizer>();
builder.Services.AddTransient<WzLoadoutRandomizer>();

builder.Services.AddCors((corsOptions) =>
{
    corsOptions.AddPolicy(CorsPolicyName, (corsPolicyBuilder) =>
    {
        corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(CorsPolicyName);

app.MapPost("/mw-loadouts", RandomizeLoadout);

static LoadoutDto RandomizeLoadout([FromServices] MwLoadoutRandomizer loadoutRandomizer, [FromBody] LoadoutHintsDto hints)
{
    MwLoadoutHints MapLoadoutHints() => new MwLoadoutHints()
    {
        EnforceUseAllWeaponAttachmentSlots = hints.EnforceUseAllWeaponAttachmentSlots
    };

    static LoadoutDto MapLoadout(Loadout loadout) => new LoadoutDto()
    {
        PrimaryWeapon = MapWeaponBuild(loadout.PrimaryWeapon),
        SecondaryWeapon = MapWeaponBuild(loadout.SecondaryWeapon),
        Perks = loadout.Perks.Select(MapIdName).ToList(),
        Lethal = MapIdName(loadout.Lethal),
        Tactical = MapIdName(loadout.Tactical),
    };

    static WeaponBuildDto MapWeaponBuild(WeaponBuild weaponBuild) => new WeaponBuildDto()
    {
        Id = weaponBuild.Weapon.Id,
        Name = weaponBuild.Weapon.Name,
        ImageUrl = weaponBuild.Weapon.ImageUrl,
        WeaponType = weaponBuild.Weapon.WeaponType,
        Attachments = weaponBuild.Attachments.Select(MapAttachment).ToList()
    };

    static AttachmentDto MapAttachment(AttachmentType attachmentType)
    {
        GameItem attachmentVariant = attachmentType.Attachments.Single();

        return new AttachmentDto()
        {
            Id = attachmentType.Id,
            Name = attachmentType.Name,
            Variant = new IdNameDto()
            {
                Id = attachmentVariant.Id,
                Name = attachmentVariant.Name
            }
        };
    }

    static IdNameDto MapIdName(GameItem gameItem) => new IdNameDto()
    {
        Id = gameItem.Id,
        Name = gameItem.Name
    };

    Loadout loadout = loadoutRandomizer.Randomize(MapLoadoutHints());

    return MapLoadout(loadout);
}

app.Run();
