using System;
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
            Vector2 example1 = new Vector2(1, 0);
            Console.WriteLine(example1.Dot(new Vector2(0, 1)));
            Vector2 example2 = new Vector2(1, 1);
            Console.WriteLine(example2.Dot(new Vector2(-1, -1)));
            Vector3 example3 = new Vector3(2, 3, 1);
            Console.WriteLine(example3.Dot(new Vector3(-3, 1, 2)));
            Vector2 example4 = new Vector2(1, 3);
            float example4Res = example4.Dot(new Vector2(0.5f, -0.25f));
            Console.WriteLine(example4.AngleBetween(example4Res));
            Vector3 example5 = new Vector3(-0.5f, 0, 2);
            float example5Res = example5.Dot(new Vector3(-1, 0, -1));
            Console.WriteLine(example5.AngleBetween(example5Res));
            Console.WriteLine(new Vector3(2f, 3f, 1f).Cross(new Vector3(-3f, 1f, 2f)));

            Console.ReadKey();
            return;


            Game game = new Game();

            game.Run();
        }
    }
}
