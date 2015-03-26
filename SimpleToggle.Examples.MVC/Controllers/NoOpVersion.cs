namespace SimpleToggle.Examples.MVC.Controllers
{
    public class NoOpVersion : IUseToggles
    {
        public string Message()
        {
            return "Hello from Toggle Off Version";
        }
    }
}