using System;

namespace app.tasks.startup.steps
{
  public delegate Exception StartupStepPolicyViolationExceptionFactory(Type misbehaving_step,Exception inner);
}