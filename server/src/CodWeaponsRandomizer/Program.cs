using Microsoft.AspNetCore.Mvc;

const string MwDbFolderPath = @".\db";
const string CorsPolicyName = "RND_COD_LDT";

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddSingleton(typeof(MwDb), MwDb.Load(MwDbFolderPath));
//builder.Services.AddTransient<WeaponBuildRandomizer>();
//builder.Services.AddTransient<LoadoutRandomizer>();

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

//app.MapPost("/loadouts", RandomizeLoadout);

//static LoadoutDto RandomizeLoadout([FromServices]LoadoutRandomizer loadoutRandomizer, [FromBody]LoadoutHintsDto hints)
//{
//    var loadout = loadoutRandomizer.Randomize(new LoadoutHints()
//    {
//        EnforceUseAllWeaponAttachments = hints.EnforceUseAllWeaponAttachments,
//        EnforceUseOverkillPerk = hints.EnforceUseOverkillPerk
//    });

//    static WeaponDto MapWeapon(CustomWeaponBuild weaponBuild) => new WeaponDto()
//    {
//        Name = weaponBuild.Weapon.Name,
//        Category = weaponBuild.Weapon.Category.Name,
//        Attachments = weaponBuild.Attachments.Select(a => new AttachmentDto()
//        {
//            Name = a.Name,
//            AttachmentCategory = a.Category.Name
//        })
//    };

//    return new LoadoutDto()
//    {
//        PrimaryWeapon = MapWeapon(loadout.PrimaryWeapon),
//        SecondaryWeapon = MapWeapon(loadout.SecondaryWeapon),
//        Perks = loadout.Perks.Select(p => new PerkDto()
//        {
//            Slot = p.Slot.Slot,
//            Name = p.Name
//        }),
//        Lethal = loadout.Lethal.Name,
//        Tactical = loadout.Tactical.Name
//    };
//}

app.Run();
