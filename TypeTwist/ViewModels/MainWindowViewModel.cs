using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace TypeTwist.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _currentLanguage;
        private readonly DispatcherTimer _languageSwitchTimer;

        public MainWindowViewModel()
        {
            _currentLanguage = "English";
            _languageSwitchTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5) // 5 saniyede bir dil değiştir
            };
            _languageSwitchTimer.Tick += SwitchKeyboardLanguage;
        }

        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    OnPropertyChanged(nameof(CurrentLanguage));
                }
            }
        }

        public ICommand StartCommand => new RelayCommand(OnStartCommand);

        private void OnStartCommand(object obj)
        {
            _languageSwitchTimer.Start();
        }

        private void SwitchKeyboardLanguage(object sender, EventArgs e)
        {
            // Basit bir dil değiştirme mantığı
            CurrentLanguage = CurrentLanguage == "English" ? "Spanish" : "English";
        }
    }

    // Basit bir ICommand implementasyonu
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
