using Lab_5.Enums;
using System;

namespace Lab_5.Models
{
    [Serializable]
    public class NinjaModel
    {
        public string Name { get; set; }

        public int Power { get; set; }

        public int HitPoints { get; set; }

        public NinjaType Image { get; set; }
    }
}