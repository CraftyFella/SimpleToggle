namespace SimpleToggle
{
    public static class TogglerExtensions
    {
        public static IToggler ToggleOn<T>(this IToggler toggler)
        {
            toggler.Toggle<T>(true);
            return toggler;
        }

        public static IToggler ToggleOff<T>(this IToggler toggler)
        {
            toggler.Toggle<T>(false);
            return toggler;
        }

        public static IToggler Toggle<T>(this IToggler toggler, bool @on)
        {
            toggler.Toggle(SimpleToggle.Toggle.NameFor<T>(), @on);
            return toggler;
        }

        public static IToggler ToggleOn(this IToggler toggler, string toggle)
        {
            toggler.Toggle(toggle, true);
            return toggler;
        }

        public static IToggler ToggleOff(this IToggler toggler, string toggle)
        {
            toggler.Toggle(toggle, false);
            return toggler;
        }
    }
}