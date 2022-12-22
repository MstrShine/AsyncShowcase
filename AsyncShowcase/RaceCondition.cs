using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncShowcase
{
    public class RaceCondition
    {
        public int Race { get; set; } = 0;

        public void Race1() { Race = 1; }
        public void Race2() { Race = 2; }
        public void Race3() { Race = 3; }
    }
}
