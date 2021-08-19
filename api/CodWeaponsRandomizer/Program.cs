using System;
using CodWeaponsRandomizer.COD.MW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

const string MwDbFolderPath = @".\db";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(MwDb), MwDb.Load(MwDbFolderPath));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/weapons", ([FromServices]MwDb db) =>
{
    return db.Weapons;
});

app.Run();
