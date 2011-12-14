﻿namespace app.web.core
{
  public interface IProcessASingleRequest
  {
    void process(IProvideDetailsToCommands request);
    bool can_process(IProvideDetailsToCommands request);
  }
}