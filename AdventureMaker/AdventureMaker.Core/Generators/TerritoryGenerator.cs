using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureMaker.Core.World;
using AdventureMaker.Core.Util;

namespace AdventureMaker.Core.Generators
{
    public class TerritoryGenerator
    {
        private List<string> Names;

        public TerritoryGenerator(int size)
        {
            SetUp(size);
        }

        private Territory GenerateTerritory()
        {
            Territory result = null;
            int _Name = Randomizer.RollDices(1, Names.Count - 1);
            result = new Territory(Names[_Name]);
            
            Names.RemoveAt(_Name);
            return result;
        }

        public List<Territory> Generate()
        {
            List<Territory> result = new List<Territory>();

            while (Names.Count > 0)
            {
                result.Add(this.GenerateTerritory());
            }
            
            return result;
        }

        private void SetUp(int size)
        {
            Names = new List<string>();
            //string[] _Names = { "Territory1","Territory2","Territory3","Territory4" };
            string[] _Names = new string[size];
            for (int i = 0; i < size; i++)
            {
                _Names[i] = "Territory" + i;
            }
            Names.AddRange(_Names);
        }

    }
}
