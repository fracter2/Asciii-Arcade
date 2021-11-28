using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Drawing;
using System.Windows;


namespace Asciii_Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Window Settings
            Console.Title = "Asciii Arcade";
            Console.SetWindowSize(120, 52);
            


            int scrnSizeY = 48;
            double scrnProp = 2;
            bool ratioMode = true;
            int scrnSizeX = (int) (ratioMode ? Math.Ceiling(scrnSizeY * scrnProp) : 40); // Go by Y to X ratio, or designated value
            

            char[] screenRow = new char[scrnSizeX];
            for (int i = 0; i < scrnSizeX; i++)
            {
                screenRow[i] = ' '; // What to use as blank
            }

                List<char[]> screen = new List<char[]>(scrnSizeY);
            for (int i = 0; i < scrnSizeY; i++)
            {
                screen.Add(screenRow);
            }

            void Render()
            {
                // Border Top
                for (int i = 0; i < scrnSizeX + 2; i++) 
                {
                    Console.Write("_");
                }
                Console.Write("\n");

                for (int i = 0; i < scrnSizeY; i++)
                {
                    Console.Write("|"); // Border Left
                    for (int i1 = 0; i1 < scrnSizeX; i1++)
                    {
                        Console.Write(screen[i][i1]);
                    }
                    Console.Write("|\n"); // Border Riddle and next line
                }

                // Border Bottom
                for (int i = 0; i < scrnSizeX + 2; i++)
                {
                    Console.Write("_");
                }
                Console.Write("\n");
            }



            

            Render();
            Console.ReadKey();


        }
    }
}
