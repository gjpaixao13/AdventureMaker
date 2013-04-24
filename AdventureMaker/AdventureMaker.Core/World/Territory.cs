using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureMaker.Core.Enums;

namespace AdventureMaker.Core.World
{
    public class Territory
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Dictionary<EDirection, Territory> _Borders;
        public Dictionary<EDirection, Territory> Borders
        {
            get { return _Borders; }
            set { _Borders = value; }
        }

        public Dictionary<EDirection, bool> BordersFlag;

        public int Level;

        public Territory(string Name)
        {
            _Borders = new Dictionary<EDirection, Territory>();
            BordersFlag = new Dictionary<EDirection, bool>();
            _Name = Name;
            _Borders.Add(Enums.EDirection.North, null);
            _Borders.Add(Enums.EDirection.South, null);
            _Borders.Add(Enums.EDirection.West, null);
            _Borders.Add(Enums.EDirection.East, null);
            BordersFlag.Add(Enums.EDirection.North, false);
            BordersFlag.Add(Enums.EDirection.South, false);
            BordersFlag.Add(Enums.EDirection.West, false);
            BordersFlag.Add(Enums.EDirection.East, false);
            Level = 0;
        }
    }
}
