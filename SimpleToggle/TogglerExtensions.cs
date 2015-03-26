namespace SimpleToggle
{
    public static class TogglerExtensions
    {
        public static void ToggleOn<T>(this IToggler toggler)
        {
            toggler.ToggleOn(SimpleToggle.Toggle.NameFor<T>());
        }

        public static void ToggleOff<T>(this IToggler toggles)
        {
            toggles.ToggleOff(SimpleToggle.Toggle.NameFor<T>());
        }

        public static void Toggle<T>(this IToggler toggles, bool @on)
        {
            toggles.Toggle(SimpleToggle.Toggle.NameFor<T>(), @on);
        }

        public static void ToggleOn(this IToggler toggles, string toggle)
        {
            toggles.Toggle(toggle, true);
        }

        public static void ToggleOff(this IToggler toggles, string toggle)
        {
            toggles.Toggle(toggle, false);
        }
    }
}