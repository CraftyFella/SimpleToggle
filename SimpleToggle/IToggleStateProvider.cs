namespace SimpleToggle
{
    public interface IToggleStateProvider
    {
        bool HasValue(string toggle);
        bool IsEnabled(string toggle);
    }
}