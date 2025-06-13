using System.Windows;
using MindLedger.AppLogic.ViewModels;

namespace MindLedger.App;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
