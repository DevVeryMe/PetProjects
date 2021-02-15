namespace Lab_7.Entities
{
    public class NinjaEquipmentEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        public int Power { get; set; }

        public decimal Price { get; set; }

        public int OwnerId { get; set; }

        public NinjaEntity Owner { get; set; }
    }
}
