using Avalonia.Controls;
using Avalonia.Input;
using TimeCopy.Desktop.ViewModels;

namespace TimeCopy.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnIso8601ExampleGotFocus(object? sender, FocusChangedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm && vm.CopyIso8601ExampleCommand.CanExecute(null))
        {
            vm.CopyIso8601ExampleCommand.Execute(null);
        }

        if (sender is TextBox textBox)
        {
            textBox.SelectAll();
        }
    }
}
