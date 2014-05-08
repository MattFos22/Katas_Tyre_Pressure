using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.Test
{
    public class Tyres:ITyreAlarmListener,IEnumerable
    {
        private Dictionary<string,Tyre> _vehicleTyres = new Dictionary<string,Tyre>();

        public void Add(string tyreName, Tyre tyre)
        {
            _vehicleTyres.Add(tyreName, tyre);
        }

        public Tyre Get(string tyreName)
        {
            return _vehicleTyres[tyreName];
        }

        public IEnumerator GetEnumerator()
        {
            return _vehicleTyres.GetEnumerator();
        }
    }
}
