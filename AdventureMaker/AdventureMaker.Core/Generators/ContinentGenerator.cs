using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureMaker.Core.World;
using AdventureMaker.Core.Util;

namespace AdventureMaker.Core.Generators
{
    public class ContinentGenerator
    {
        private List<string> Names;

        public ContinentGenerator()
        {
            SetUp();
        }

        public Continent Generate()
        {
            Continent result = null;
            TerritoryGenerator _TerritoryGenerator = new TerritoryGenerator(20);
            int _Name = Randomizer.RollDices(1, Names.Count - 1);
            result = new Continent(Names[_Name]);
            result.Territories = _TerritoryGenerator.Generate();
            result.Territories = CreatingLevels(result.Territories);
            result.Territories = CreatingBorders(result.Territories);
            return result;
        }

        private void SetUp()
        {
            Names = new List<string>();
            string[] _Names = { "Continent1", "Continent2", "Continent3", "Continent4" };
            Names.AddRange(_Names);
        }

        private List<Territory> CreatingBorders(List<Territory> Territories)
        {
            bool aux = false;//Flag to see if the border is valid
            for (int i = 0; i < Territories.Count; i++) //To add borders to all Territories
            {
                bool vNorth, vSouth, vEast, vWest;
                vNorth = vSouth = vEast = vWest = true;
                int index = Randomizer.RollDices(1, Territories.Count - 1);//Get a random Territory          
                for (int k = 0; k < 2; k++)
                {
                    while (true)
                    {
                        vNorth = vSouth = vEast = vWest = true;

                        index = Randomizer.RollDices(1, Territories.Count - 1);//Get a random Territory
                        if (Territories[index].BordersFlag[Enums.EDirection.North] || Territories[index].Level < Territories[i].Level)
                        {
                            vNorth = false;
                        }
                        if (Territories[index].BordersFlag[Enums.EDirection.South] || Territories[index].Level > Territories[i].Level)
                        {
                            vSouth = false;
                        }
                        if (Territories[index].BordersFlag[Enums.EDirection.East] || Territories[index].Level != Territories[i].Level)
                        {
                            vEast = false;
                        }
                        if (Territories[index].BordersFlag[Enums.EDirection.West] || Territories[index].Level != Territories[i].Level)
                        {
                            vWest = false;
                        }
                        if ((vNorth != false || vSouth != false || vEast != false || vWest != false))
                            if (index != i)
                                break;
                    }

                    if (vNorth)
                    {
                        if (Territories[i].Borders[Enums.EDirection.South] == null && Territories[index].Borders[Enums.EDirection.North] == null && !Territories[i].Borders.ContainsValue(Territories[index]) && !Territories[index].Borders.ContainsValue(Territories[i]))
                        {
                            Territories[i].Borders[Enums.EDirection.South] = Territories[index];
                            Territories[i].BordersFlag[Enums.EDirection.South] = true;
                            Territories[index].Borders[Enums.EDirection.North] = Territories[i];
                            Territories[index].BordersFlag[Enums.EDirection.North] = true;
                        }
                    }
                    else if (vSouth)
                    {
                        if (Territories[index].Borders[Enums.EDirection.South] == null && Territories[i].Borders[Enums.EDirection.North] == null && !Territories[i].Borders.ContainsValue(Territories[index]) && !Territories[index].Borders.ContainsValue(Territories[i]))
                        {
                            Territories[i].Borders[Enums.EDirection.North] = Territories[index];
                            Territories[i].BordersFlag[Enums.EDirection.North] = true;
                            Territories[index].Borders[Enums.EDirection.South] = Territories[i];
                            Territories[index].BordersFlag[Enums.EDirection.South] = true;
                        }
                    }
                    else if (vEast)
                    {
                        if (Territories[index].Borders[Enums.EDirection.East] == null && Territories[i].Borders[Enums.EDirection.West] == null && !Territories[i].Borders.ContainsValue(Territories[index]) && !Territories[index].Borders.ContainsValue(Territories[i]))
                        {
                            if (Territories[i].Borders[Enums.EDirection.East] == null || Territories[i].Borders[Enums.EDirection.East] != Territories[index])
                            {
                                Territories[i].Borders[Enums.EDirection.West] = Territories[index];
                                Territories[i].BordersFlag[Enums.EDirection.West] = true;
                                Territories[index].Borders[Enums.EDirection.East] = Territories[i];
                                Territories[index].BordersFlag[Enums.EDirection.East] = true;
                            }
                        }
                    }
                    else if (vWest)
                    {
                        if (Territories[i].Borders[Enums.EDirection.East] == null && Territories[index].Borders[Enums.EDirection.West] == null && !Territories[i].Borders.ContainsValue(Territories[index]) && !Territories[index].Borders.ContainsValue(Territories[i]))
                        {
                            if (Territories[i].Borders[Enums.EDirection.West] == null || Territories[i].Borders[Enums.EDirection.West] != Territories[index])
                            {
                                Territories[i].Borders[Enums.EDirection.East] = Territories[index];
                                Territories[i].BordersFlag[Enums.EDirection.East] = true;
                                Territories[index].Borders[Enums.EDirection.West] = Territories[i];
                                Territories[index].BordersFlag[Enums.EDirection.West] = true;
                            }
                        }
                    }
                }
            }

            return Territories;
        }

        private List<Territory> CreatingLevels(List<Territory> Territories)
        {
            int count = Territories.Count;
            int nLevel = (count / 4);
            List<Territory> aux = new List<Territory>();
            List<int> Counter = new List<int>();
            for (int i = 0; i < nLevel; i++)
            {
                Counter.Add(count / nLevel);
            }
            aux.AddRange(Territories);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < Counter.Count; j++)
                {
                    if (Counter[j] > 0)
                    {
                        Territories[i].Level = Counter[j];
                        Counter[j]--;
                    }
                }
            }
            return Territories;
        }
    }
}
