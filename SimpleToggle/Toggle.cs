using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleToggle
{
    public class Toggle
    {
        public class Registry
        {
            private static readonly HashSet<string> _store = new HashSet<string>();

            public static IEnumerable<string> All
            {
                get { return _store; }
            }

            public static void Add<T>()
            {
                Add(NameFor<T>());
            }

            public static void Add(string toggle)
            {
                _store.Add(toggle);
            }

            public static void Clear()
            {
                _store.Clear();
            }

            public static bool Contains(string toggle)
            {
                return _store.Contains(toggle);
            }
        }

        public class Providers
        {
            private static readonly IList<IProvider> _store = new List<IProvider>();
            public static IEnumerable<IProvider> All
            {
                get { return _store; }
            }

            public static void Clear()
            {
                _store.Clear();
            }

            public static void Add(IProvider provider)
            {
                _store.Add(provider);
            }
        }
        
        public static string NameFor<T>()
        {
            return typeof(T).Name;
        }

        public static bool Enabled<T>()
        {
            return Enabled(NameFor<T>());
        }

        public static bool Enabled(string toggle)
        {
            if (!Registry.Contains(toggle))
            {
                throw new UnRegisteredToggleException(toggle);
            }

            var provider = Providers.All
                .FirstOrDefault(p => p.HasValue(toggle));

            return provider != null && provider.IsEnabled(toggle);
        }
    }

    public class UnRegisteredToggleException : Exception
    {
        public UnRegisteredToggleException(string toggle)
            : base(string.Format("Toggle {0} has not been registered", toggle))
        {

        }
    }
}