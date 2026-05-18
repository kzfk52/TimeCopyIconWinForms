using Avalonia.Controls;
using Avalonia.Input;
using TimeCopy.Desktop.ViewModels;

namespace TimeCopy.Desktop.Views;

public partial class MainWindow : Window
{
    public bool IsClosingForReal { get; set; }

    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (!IsClosingForReal)
        {
            e.Cancel = true;
            Hide();
        }

        base.OnClosing(e);
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
