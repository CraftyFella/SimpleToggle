using System;

namespace SimpleToggle
{
    public class UnRegisteredToggleException : Exception
    {
        public UnRegisteredToggleException(string toggle)
            : base(string.Format("Feature {0} has not been registered", toggle))
        {

        }
    }
}