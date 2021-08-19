using System;
using CodWeaponsRandomizer.COD.MW;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

const string MwDbFolderPath = "";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(MwDb), MwDb.Load(MwDbFolderPath));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.Run();
