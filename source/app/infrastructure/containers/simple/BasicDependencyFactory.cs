namespace app.infrastructure.containers.simple
{
    using System;

    public class BasicDependencyFactory : ICreateADependency
    {
        Func<object> connection;

        public BasicDependencyFactory(Func<object> connection)
        {
            this.connection = connection;
        }

        public object create()
        {
            return connection();
        }
  }
}