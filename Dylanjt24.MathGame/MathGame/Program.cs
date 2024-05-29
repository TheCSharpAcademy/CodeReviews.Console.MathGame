using MathGame;
using static System.Formats.Asn1.AsnWriter;

var menu = new Menu();
var date = DateTime.UtcNow;
string name = Helpers.GetName();

menu.ShowMenu(name, date);

