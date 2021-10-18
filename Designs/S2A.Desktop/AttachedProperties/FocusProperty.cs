using System.Windows;
using System.Windows.Controls;

namespace S2A.Desktop
{
    /// <summary>
    /// Focuses (keyboard focus) this element if true
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, return
            if (!(sender is Control control))
                return;

            if ((bool)e.NewValue)
                // Focus this control
                control.Focus();
        }
    }
}
