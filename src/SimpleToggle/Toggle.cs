using System.Collections.Generic;
using System.Linq;

namespace SimpleToggle
{
    public static class Toggle
    {
        static readonly HashSet<string> Registry = new HashSet<string>();

        public static IEnumerable<string> All
        {
            get { return Registry; }
        }

        public static void Register<T>()
        {
            Register(NameFor<T>());
        }

        public static void Register(string toggle)
        {
            Registry.Add(toggle);
        }

        public static void ResetAll()
        {
            Registry.Clear();
            Providers.Clear();
        }

        public static class Providers
        {
// ReSharper disable once MemberHidesStaticFromOuterClass
            static readonly IList<IProvider> All = new List<IProvider>();

            public static IProvider Matching(string toggle)
            {
                return All
                    .FirstOrDefault(p => p.Contains(toggle));    
            }

            public static void Clear()
            {
                All.Clear();
            }

            public static void Add(IProvider provider)
            {
                All.Add(provider);
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
            if (!Registry.Contains(toggle))
            {
                throw new UnRegisteredToggleException(toggle);
            }

            var provider = Providers.Matching(toggle);
            return provider != null && provider.IsEnabled(toggle);
        }
    }
}