using System;
using System.Data;
using System.Linq;

namespace app
{
    using System.Security;
    using System.Security.Principal;
    using System.Threading;

    public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection,int number,int number2)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      ensure_all_are_positive(first, second);

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

        IPrincipal principal = Thread.CurrentPrincipal;
        if(principal.IsInRole(""))
        {
            this.shut_off();
        }

        return first + second;
    }

    static void ensure_all_are_positive(params int[] numbers)
    {
      if (numbers.Any(x => x < 0)) throw new ArgumentException("no!");
    }

    public void shut_off()
    {
      throw new SecurityException();
    }
  }
}