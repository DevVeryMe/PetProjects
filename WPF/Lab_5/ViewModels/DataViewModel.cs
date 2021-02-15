using Lab_5.Commands;
using Lab_5.Enums;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lab_5.ViewModels
{
    public class DataViewModel : BaseViewModel
    {
        private string _visibleControl = "Ninjas";

        private ObservableCollection<NinjaViewModel> _ninjas = new ObservableCollection<NinjaViewModel>();

        private ObservableCollection<NinjaType> _ninjaTypes = new ObservableCollection<NinjaType>();

        private NinjaViewModel _selectedNinja;

        private ICommand _rankUp;

        private ICommand _setControlVisibility;

        public ObservableCollection<NinjaViewModel> Ninjas
        {
            get => _ninjas;
            set
            {
                _ninjas = value;
                OnPropertyChanged(nameof(Ninjas));
            }
        }

        public ObservableCollection<NinjaType> NinjaTypes
        {
            get => _ninjaTypes;
            set
            {
                _ninjaTypes = value;
                OnPropertyChanged(nameof(NinjaTypes));
            }
        }

        public NinjaViewModel SelectedNinja
        {
            get => _selectedNinja;
            set
            {
                _selectedNinja = value;
                OnPropertyChanged(nameof(SelectedNinja));
            }
        }

        public string VisibleControl
        {
            get => _visibleControl;
            set
            {
                _visibleControl = value;
                OnPropertyChanged(nameof(VisibleControl));
            }
        }

        public ICommand RankUp
        {
            get
            {
                return _rankUp ?? new CustomCommand((ninjaType) =>
                {
                    SelectedNinja.Image = SelectedNinja.Image == NinjaType.Kage
                        ? NinjaType.Kage
                        : (NinjaType)((int)SelectedNinja.Image + 1);
                });
            }
        }

        public ICommand RankDown
        {
            get
            {
                return _rankUp ?? new CustomCommand((ninjaType) =>
                {
                    SelectedNinja.Image = SelectedNinja.Image == NinjaType.Genin
                        ? NinjaType.Genin
                        : (NinjaType)((int)SelectedNinja.Image - 1);
                });
            }
        }

        public ICommand SetControlVisibility
        {
            get
            {
                return _setControlVisibility ?? new CustomCommand((control) =>
                {
                    VisibleControl = control.ToString();
                });
            }
        }
    }
}
