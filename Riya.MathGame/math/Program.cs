using System;
using static System.Formats.Asn1.AsnWriter;
using math;
string name = Helpers.GetName();

var date = DateTime.UtcNow;
//List declaration ways
// List<string> games =  new List<string>();  1 ways
// List<string> games =  new(); 2 way

//var games = new List<string>(); //3rd way
var menu = new Menu();

menu.showMenu(name , date);




