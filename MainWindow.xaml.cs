using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System.Collections.Generic;

namespace AutoSuggestBoxTest
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void myAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = new List<string> { "Apple", "Banana", "Orange", "Grape", "Peach" };
                sender.ItemsSource = suggestions.FindAll(item => item.StartsWith(sender.Text, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        void myAutoSuggestBox_PointerEntered(object sender, PointerRoutedEventArgs e) => uiPopup.IsOpen = true;

        void myAutoSuggestBox_LostFocus(object sender, RoutedEventArgs e) => uiPopup.IsOpen = false;
    }
}
