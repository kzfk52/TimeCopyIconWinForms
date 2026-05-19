using System;
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
        // On macOS, keep the app alive in the menu bar when the user clicks the
        // window's red close button (standard mac behavior). On Windows we honor
        // the local convention that closing the window quits the app. Shutdown
        // paths (tray "終了", Dock → Quit, OS logoff) always pass through.
        var isUserClosing = e.CloseReason == WindowCloseReason.WindowClosing;
        if (!IsClosingForReal && isUserClosing && OperatingSystem.IsMacOS())
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
