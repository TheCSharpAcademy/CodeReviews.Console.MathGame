// See https://aka.ms/new-console-template for more information

using Math_Game_v2;
using Math_Game_v2.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();
        
        DateTime date = DateTime.Now; // Better to use DateTime variable type with... dates.
        
        var username = Helpers.GetUsername();

        menu.ShowMenu(username,date);
        
       
    }
}

     

    