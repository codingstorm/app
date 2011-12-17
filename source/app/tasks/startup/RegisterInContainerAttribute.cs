using System;

namespace app.tasks.startup
{
  [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
  public class RegisterInContainerAttribute : Attribute
  {
    bool polymorphic_registration;
    Type contract_type;

    public RegisterInContainerAttribute(params Type[] contracts):this(false,contracts)
    {
    }
    public RegisterInContainerAttribute(bool polymorphic_registration,params Type[] contracts)
    {
      this.polymorphic_registration = polymorphic_registration;
      this.contract_type = contract_type;
    }
  }
}