using System.Windows;
using TypeTwist.ViewModels;

namespace TypeTwist
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
