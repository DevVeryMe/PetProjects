using System.Collections.Generic;

namespace Lab_7.Entities
{
    public class NinjaEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public int HitPower { get; set; }

        public int HealthPoints { get; set; }

        public ICollection<NinjaEquipmentEntity> Items { get; set; }
    }
}
