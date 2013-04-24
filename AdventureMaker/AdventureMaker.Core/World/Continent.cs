using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdventureMaker.Core.World
{
    public class Continent
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private List<Territory> _Territories;
        public List<Territory> Territories
        {
            get { return _Territories; }
            set { _Territories = value; }
        }


        public Continent(string Name)
        {
            _Name = Name;
            _Territories = new List<Territory>();
        }
    }
}
