﻿using MathGame.gmonestere;

var menu = new Menu();

var date = DateTime.UtcNow;

var games = new List<string>();

string name = Helpers.GetName();

menu.ShowMenu(name, date);