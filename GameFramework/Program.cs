﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {            
            Game game = new Game();

            game.Run();
        }

        static void Examples()
        {
            Vector2 example1 = new Vector2(1, 0);
            Console.WriteLine(example1.Dot(new Vector2(0, 1)));
            Vector2 example2 = new Vector2(1, 1);
            Console.WriteLine(example2.Dot(new Vector2(-1, -1)));
            Vector3 example3 = new Vector3(2, 3, 1);
            Console.WriteLine(example3.Dot(new Vector3(-3, 1, 2)));           
            Console.WriteLine(new Vector2(1, 3).AngleBetween(new Vector2(0.5f, -0.25f)));
            Console.WriteLine(new Vector3(-0.5f, 0f, 2f).AngleBetween(new Vector3(-1f, 0f, -1f)));
            Console.WriteLine(new Vector3(2f, 3f, 1f).Cross(new Vector3(-3f, 1f, 2f)));

            Vector3 playerLoc = new Vector3(10f, 0f, 18f);
            Vector3 enemyLoc = new Vector3(-7.5f, 0, 9f);
            Vector3 enemyDir = new Vector3(0.857f, 0f, -0.514f);
            Vector3 up = new Vector3(0f, 1f, 0f);

            Vector3 enemyToPlayer = playerLoc - enemyLoc;
            Console.WriteLine("Distance from enemy to player: " + enemyToPlayer);

            if (enemyDir.Dot(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is in front of enemy.");
            }
            else
            {
                Console.WriteLine("Player is behind enemy.");
            }

            Vector3 enemyLeft = enemyDir.Cross(up);
            if (enemyLeft.Dot(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is left of enemy.");
            }
            else
            {
                Console.WriteLine("Player is right of enemy.");
            }

            if (enemyDir.AngleBetween(enemyToPlayer) <= Math.PI / 4 || enemyDir.AngleBetween(enemyToPlayer) >= 7 * Math.PI / 4) ;
            {
                Console.WriteLine("I fought mudcrabs tougher than you!");
            }

            Console.ReadKey();
        }
    }
}
