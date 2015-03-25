namespace SimpleToggle
{
    public interface IProvider
    {
        bool HasValue(string toggle);
        bool IsEnabled(string toggle);
    }
}