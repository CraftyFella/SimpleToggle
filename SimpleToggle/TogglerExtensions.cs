namespace SimpleToggle
{
    public static class TogglerExtensions
    {
        public static void ToggleOn<T>(this IToggler toggler)
        {
            toggler.ToggleOn(Toggle.NameFor<T>());
        }

        public static void ToggleOff<T>(this IToggler toggles)
        {
            toggles.ToggleOff(Toggle.NameFor<T>());
        }
    }
}