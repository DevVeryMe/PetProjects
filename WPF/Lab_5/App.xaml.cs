using AutoMapper;
using Lab_5.Mappings;
using Lab_5.Models;
using Lab_5.ViewModels;
using System;
using System.Windows;

namespace Lab_5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataModel _dataModel;
        private DataViewModel _dataViewModel;

        private IMapper _mapper;

        public App()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfig.CreateMapper();

            _dataModel = DataModel.Load();
            _dataViewModel = _mapper.Map<DataViewModel>(_dataModel);

            var window = new MainWindow() { DataContext = _dataViewModel };
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                _dataModel = _mapper.Map<DataModel>(_dataViewModel);
                _dataModel.Save();
            }
            catch (Exception)
            {
                base.OnExit(e);
                throw;
            }
        }
    }
}
