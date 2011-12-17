namespace app.tasks.startup
{
  public interface IConfigureRegistrationOptions<ContractOfItem>
  {
    void as_singleton();
    void decorate_with<Decorator>() where Decorator : ContractOfItem;
    void register_polymorphically();
  }
}