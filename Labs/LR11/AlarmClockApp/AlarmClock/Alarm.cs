using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsActive { get; set; }
        public bool Repeat { get; set; }
        public string Name { get; set; }
    }
}
