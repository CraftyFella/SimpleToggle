namespace SimpleToggle
{
    public interface IToggler
    {
        IToggler Toggle(string toggle, bool on);
    }
}