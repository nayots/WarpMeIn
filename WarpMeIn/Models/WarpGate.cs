using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpMeIn.Models
{
    public class WarpGate
    {
        public long Id { get; protected set; }
        public string ANKey { get; protected set; }
        public string URLFullPath { get; protected set; }
        public int WarpCount { get; protected set; }
        public bool Enabled { get; protected set; } = true;
    }
}
