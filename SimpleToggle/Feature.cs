using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleToggle
{
    public class Feature
    {
        private static readonly HashSet<string> _registry = new HashSet<string>();

        public static IEnumerable<string> All
        {
            get { return _registry; }
        }

        public static void Register<T>()
        {
            Register(NameFor<T>());
        }

        public static void Register(string toggle)
        {
            _registry.Add(toggle);
        }

        public static void ResetAll()
        {
            _registry.Clear();
            Providers.Clear();
        }

        public class Providers
        {
            private static readonly IList<IProvider> _all = new List<IProvider>();
            public static IProvider Matching(string toggle)
            {
                return _all
                    .FirstOrDefault(p => p.Contains(toggle));    
            }

            public static void Clear()
            {
                _all.Clear();
            }

            public static void Add(IProvider provider)
            {
                _all.Add(provider);
            }
        }
        
        public static string NameFor<T>()
        {
            return typeof(T).Name;
        }

        public static bool IsEnabled<T>()
        {
            return IsEnabled(NameFor<T>());
        }

        public static bool IsEnabled(string toggle)
        {
            if (!_registry.Contains(toggle))
            {
                throw new UnRegisteredToggleException(toggle);
            }

            var provider = Providers.Matching(toggle);
            return provider != null && provider.IsEnabled(toggle);
        }
    }

    public class UnRegisteredToggleException : Exception
    {
        public UnRegisteredToggleException(string toggle)
            : base(string.Format("Feature {0} has not been registered", toggle))
        {

        }
    }
}