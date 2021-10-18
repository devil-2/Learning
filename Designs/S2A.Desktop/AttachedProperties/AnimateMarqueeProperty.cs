using System.Windows;

namespace S2A.Desktop
{
    /// <summary>
    /// Animates a framework element sliding it from right to left and repeating forever
    /// </summary>
    public class AnimateMarqueeProperty : AnimateBaseProperty<AnimateMarqueeProperty>
    {
        protected override void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            // Animate in
            element.MarqueeAsync(firstLoad ? 0 : 3f);
        }
    }
}
