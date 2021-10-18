using System.Windows;
using System.Windows.Controls;

namespace S2A.Desktop
{
    /// <summary>
    /// Fades in an image once the source changes
    /// </summary>
    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Make sure we have an image
            if (!(sender is Image image))
                return;

            // If we want to animate in...
            if ((bool)value)
                // Listen for target change
                image.TargetUpdated += Image_TargetUpdatedAsync;
            // Otherwise
            else
                // Make sure we unhooked
                image.TargetUpdated -= Image_TargetUpdatedAsync;
        }

        private async void Image_TargetUpdatedAsync(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            // Fade in image
            await (sender as Image).FadeInAsync(false);
        }
    }
}
