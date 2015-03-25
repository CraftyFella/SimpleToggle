using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleToggle
{
    public class Toggle
    {
        public class Config
        {
            static Config()
            {
                NoToggleBehaviour = DefaultNoToggleBehaviour;
            }

            private static bool DefaultNoToggleBehaviour(string toggle)
            {
                throw new KeyNotFoundException(string.Format("Toggle {0} could not be found in any of the {1} ToggleStateProviders", toggle, Providers.Count));
            }

            public static readonly IList<IProvider> Providers = new List<IProvider>();
            public static Func<string, bool> NoToggleBehaviour { get; set; }

            public static void Default()
            {
                Providers.Clear();
                NoToggleBehaviour = DefaultNoToggleBehaviour;
            }
        }
        
        public static string NameFor<T>()
        {
            return typeof(T).FullName;
        }

        public static bool Enabled<T>()
        {
            return Enabled(NameFor<T>());
        }
        
        public static bool Enabled(string toggle)
        {
            var provider = Config.Providers
                .FirstOrDefault(p => p.HasValue(toggle));

            return provider == null ? Config.NoToggleBehaviour(toggle) : provider.IsEnabled(toggle);
        }
    }
}