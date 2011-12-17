using System;
using app.infrastructure;

namespace app.web.core
{
  public class TimedFrontController : IProcessRequests
  {
    IProcessRequests original;
    ITimeThings timer;

    public TimedFrontController(IProcessRequests original, ITimeThings timer)
    {
      this.original = original;
      this.timer = timer;
    }

    public void process(IProvideDetailsToCommands request)
    {
      throw new NotImplementedException();
    }
  }
}