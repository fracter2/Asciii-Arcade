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
            

            char[] screenRow = new char[scrnSizeX]; // Basic empty row gen
            for (int i = 0; i < scrnSizeX; i++)
            {
                screenRow[i] = ' '; // What to use as blank
            }

                List<char[]> screen = new List<char[]>(scrnSizeY); // basic empty screen maker
            for (int i = 0; i < scrnSizeY; i++)
            {
                screen.Add(screenRow);
            }


            void Render() // Renders what is inside the screen with border
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

            // void menu () {}

            void SnakeGame()
            {
                
                List<SnakeSegment> snakeBody = new List<SnakeSegment>();
                SnakeSegment snakeSegBase = new SnakeSegment(0, 0);
                int velX = 1;
                int velY = 0;

                snakeBody.Add(snakeSegBase); // Set the start body
                snakeBody.Add(snakeSegBase);
                snakeBody.Add(snakeSegBase);


                void physicsStep()
                {
                    // Heart Loop
                    // Player Input

                    snakeBody[0].posX += velX;
                    snakeBody[0].posY += velY;

                    for (int i = 1; i >= snakeBody.Count(); i--) // Updates the position of the segments from the back
                    {
                        int t = snakeBody.Count();
                        snakeBody[t].posX = snakeBody[t - 1].posX;
                        snakeBody[t].posY = snakeBody[t - 1].posY;
                    }

                    Render();
                }
                

                
            }
            

            
            Console.ReadKey();


        }
    }

    public class GameObject
    {
        public int posX;
        public int posY;
    }

    public class SnakeSegment: GameObject
    {

        

        public SnakeSegment(int x, int y)
        {
            posX = x;
            posY = y;
        }

    }

    public class SnakeHead: GameObject
    {
        

        public SnakeHead(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }
}
