﻿// See https://aka.ms/new-console-template for more information

using CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom;

Console.ForegroundColor = ConsoleColor.Green;

var weapons = new ModernWarfareWeaponsHomePageScraper().Scrap();

return 0;