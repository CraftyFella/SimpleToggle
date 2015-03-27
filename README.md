SimpleToggle
============
Very Simple Feature Toggle Library

Setup
-
    Toggle.Providers.Add(new CookieProvider());
    Toggle.Register("Toggle1");
    Toggle.Register<TypedToggle>();
  
Usage
-
    if (Toggle.Enabled<TypedToggle>())
    {
        // New Funky stuff
    }
    else
    {
        // No Op Behaviour
    }
