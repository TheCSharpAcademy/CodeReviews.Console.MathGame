
using Math_Game;
using System.Threading.Channels;
using static System.Formats.Asn1.AsnWriter;

var menu = new Menu();

var date = DateTime.UtcNow;

//var games = new List<string>(); I don't think this does anything anymore 

string name = Helpers.GetName();

menu.ShowMenu(name, date);



