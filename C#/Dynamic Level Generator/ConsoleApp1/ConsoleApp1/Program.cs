using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGen
{
    public class MapGenerator
    {

        public int seed;
        public string[,] plottedMap = new string[5, 5];
        public int primeRoomX, primeRoomY;

        static void Main(string[] args)
        {

            MapGenerator mapGen = new MapGenerator();
            mapGen.GetNewSeed();

            Console.WriteLine("This is the Seed: {0}", mapGen.seed);
            Console.ReadKey();

            mapGen.GenerateNewMap();
            mapGen.DrawMap();

            Console.ReadKey();

        }

        public void GenerateNewMap()
        {
            /*
            plottedMap[0, 0] = "X";
            plottedMap[0, 1] = "X";
            plottedMap[0, 2] = "X";
            plottedMap[0, 3] = "X";
            plottedMap[0, 4] = "X";
            */

            Random plotGen = new Random(seed);
            int i, j;

            //Generate entrance room on the first row of the Map
            i = 0;
            j = plotGen.Next(0, 5);
            Console.WriteLine("This is the current Coordinate: " + i + ", " + j);
            Console.ReadKey();
            primeRoomX = i;
            primeRoomY = j;
            plottedMap[i,j] = GetOrientation(i,j);


            //Based on the position of the entrance, determine whether the next room will be on the same row or the next one.



            //Placing next room based on previous generated room.

        }

        public int GetNewSeed()
        {

            Random seedGen = new Random();
            return (seed = seedGen.Next(10000, 999999));

        }

        public void DrawMap() {

            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine("{0}|{1}|{2}|{3}|{4} ", plottedMap[i, 0], plottedMap[i, 1], plottedMap[i, 2], plottedMap[i, 3],plottedMap[i, 4]);

            }
            Console.WriteLine();

        }

        public string GetOrientation(int i, int j) {

            string translatedOrientation = null;
            Random orientationGen = new Random(seed);
            int newOrientation = 0;

            //If Room is on Topmost Bound...
            if (i == 0)
            {

                List<int> orientation = new List<int> { 1, 2, 3, 4 };
                int index = orientationGen.Next(orientation.Count);
                newOrientation = orientation[index];

            }
            //If Room is on Bottommost Bound...
            else if (i == 4)
            {

                List<int> orientation = new List<int> { 0, 1, 3, 4 };
                int index = orientationGen.Next(orientation.Count);
                newOrientation = orientation[index];

            }
            //If Room is on LeftMost..
            else if (j == 0)
            {

                List<int> orientation = new List<int> { 0, 1, 2, 3 };
                int index = orientationGen.Next(orientation.Count);
                newOrientation = orientation[index];

            }
            //If Room is on Rightmost Bound...
            else if (j == 4)
            {

                List<int> orientation = new List<int> { 0, 1, 2, 4 };
                int index = orientationGen.Next(orientation.Count);
                newOrientation = orientation[index];

            }
            else
            {

                List<int> orientation = new List<int> { 0, 1, 2, 3, 4 };
                int index = orientationGen.Next(orientation.Count);
                newOrientation = orientation[index];

            }


            //...then translate the orientaiton.

            if (newOrientation == 0) {

                translatedOrientation = "^";

            }

            if (newOrientation == 1) {

                translatedOrientation = ">";

            }

            if (newOrientation == 2) {

                translatedOrientation = "V";

            }

            if (newOrientation == 3) {

                translatedOrientation = "<";

            }

            return translatedOrientation;
        }

        public int[,] GetNextRoom(int i, int j) {


            return null;
        }

    }

}
