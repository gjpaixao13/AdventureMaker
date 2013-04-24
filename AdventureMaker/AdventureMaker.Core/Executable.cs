using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AdventureMaker.Core.Generators;
using AdventureMaker.Core.World;

namespace AdventureMaker.Core
{
    public class Executable
    {
        public void Run()
        {
            ContinentGenerator _ContinentGenerator = new ContinentGenerator();
            Continent _Continent = _ContinentGenerator.Generate();

            #region Debug
            printOut(_Continent.Name);
            foreach (var item in _Continent.Territories)
            {
                string north, south, west, east;
                north = south = west = east = string.Empty;
                if (item.Borders[Enums.EDirection.North] != null)
                    north = item.Borders[Enums.EDirection.North].Name;
                if (item.Borders[Enums.EDirection.South] != null)
                    south = item.Borders[Enums.EDirection.South].Name;
                if (item.Borders[Enums.EDirection.West] != null)
                    west = item.Borders[Enums.EDirection.West].Name;
                if (item.Borders[Enums.EDirection.East] != null)
                    east = item.Borders[Enums.EDirection.East].Name;

                string message = item.Name + "\nBorders :\n -North " + north + "\n -South " + south +
                    "\n -East " + east + "\n -West " + west;
                printOut(message);

            }
            #endregion
        }


        [Conditional("DEBUG")]
        private void printOut(string Message)
        {
            Console.WriteLine(Message);
        }

    }
}
