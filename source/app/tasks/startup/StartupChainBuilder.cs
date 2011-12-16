namespace app.tasks.startup
{
    using System;
    using System.Collections.Generic;

    public class StartupChainBuilder : ICreateStartupChains
    {
        IList<Type> all_types;
        Type type;

        public StartupChainBuilder(IList<Type> allTypes, Type type)
        {
            all_types = allTypes;
            this.type = type;
            all_types.Add(this.type);
        }
    }
}