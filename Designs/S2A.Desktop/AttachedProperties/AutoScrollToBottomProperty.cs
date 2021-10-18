using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace S2A.Desktop
{
    /// <summary>
    /// Automatically keep the scroll at the bottom of the screen when we are already close to the bottom
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Don't do this in design time
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // If we don't have a control, return
            if (!(sender is ScrollViewer control))
                return;

            // Scroll content to bottom when context changes
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            // If we are close enough to the bottom...
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                // Scroll to the bottom
                scroll.ScrollToEnd();
        }
    }
}
