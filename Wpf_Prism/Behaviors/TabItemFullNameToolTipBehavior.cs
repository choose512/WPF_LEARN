using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf_Prism.Behaviors
{
    public static class TabItemFullNameToolTipBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(TabItemFullNameToolTipBehavior),
                new PropertyMetadata(false, OnIsEnabledChanged));

        public static bool GetIsEnabled(DependencyObject element) =>
            (bool)element.GetValue(IsEnabledProperty);

        public static void SetIsEnabled(DependencyObject element, bool value) =>
            element.SetValue(IsEnabledProperty, value);

        private static void OnIsEnabledChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is not TabItem tabItem)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                tabItem.MouseEnter += OnMouseEnter;
            }
            else
            {
                tabItem.MouseEnter -= OnMouseEnter;
                tabItem.ClearValue(FrameworkElement.ToolTipProperty);
            }
        }

        private static void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is not TabItem { Content: not null } tabItem)
            {
                return;
            }

            tabItem.ToolTip = tabItem.Content.GetType().FullName;
        }
    }
}
