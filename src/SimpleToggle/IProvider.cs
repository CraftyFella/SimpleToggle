namespace SimpleToggle
{
    public interface IProvider
    {
        bool Contains(string toggle);
        bool IsEnabled(string toggle);
    }
}