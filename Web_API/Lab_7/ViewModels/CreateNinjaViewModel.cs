using System.ComponentModel.DataAnnotations;

namespace Lab_7.ViewModels
{
    public class CreateNinjaViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name length error.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Rank is required.")]
        [StringLength(100, ErrorMessage = "Rank length error.")]
        public string Rank { get; set; }

        [Required(ErrorMessage = "HitPower is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "HitPower less than 1.")]
        public int HitPower { get; set; }

        [Required(ErrorMessage = "HealthPoints field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "HealthPoints less than 1.")]
        public int HealthPoints { get; set; }
    }
}
