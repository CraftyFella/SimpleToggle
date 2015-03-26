namespace SimpleToggle
{
    public static class TogglerExtensions
    {
        public static void ToggleOn<T>(this IToggler toggler)
        {
            toggler.Toggle<T>(true);
        }

        public static void ToggleOff<T>(this IToggler toggler)
        {
            toggler.Toggle<T>(false);
        }

        public static void Toggle<T>(this IToggler toggles, bool @on)
        {
            toggles.Toggle(Feature.NameFor<T>(), @on);
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