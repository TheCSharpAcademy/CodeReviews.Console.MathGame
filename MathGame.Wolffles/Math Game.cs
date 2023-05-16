using System;

namespace Math_Game;

internal class Math_Game

{
    static void Main()
    {
        Menu menu = new Menu();
        menu.initializeMenuParameters();

        while (menu.startMenu());
   
    }
}