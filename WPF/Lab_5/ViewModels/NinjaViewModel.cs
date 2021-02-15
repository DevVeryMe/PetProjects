using Lab_5.Enums;

namespace Lab_5.ViewModels
{
    public class NinjaViewModel : BaseViewModel
    {
        private string _name;
        private int _power;
        private int _hitPoints;
        private NinjaType _image;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Power
        {
            get => _power;
            set
            {
                _power = value;
                OnPropertyChanged(nameof(Power));
            }
        }

        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public NinjaType Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
    }
}