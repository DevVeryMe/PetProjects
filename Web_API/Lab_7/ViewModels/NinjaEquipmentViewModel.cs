using System.ComponentModel.DataAnnotations;

namespace Lab_7.ViewModels
{
    public class NinjaEquipmentViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id less than 1.")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title length error.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Level is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Level less than 1.")]
        public int Level { get; set; }

        [Required(ErrorMessage = "Power is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Power less than 1.")]
        public int Power { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "OwnerId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "OwnerId less than 1.")]
        public int OwnerId { get; set; }
    }
}
