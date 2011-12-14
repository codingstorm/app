 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{
    using System.Collections.Generic;
    using System.ComponentModel;

    [Subject(typeof(ViewTheDepartmentsInADepartment))]  
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewTheDepartmentsInADepartment>
    {
        
    }

   
    public class when_run : concern
    {

        Establish c = () =>
            {
                department_repository = depends.on<IFindDepartments>();
                report_engine = depends.on<IDisplayReports>();
                
                department = new DepartmentItem();
                the_sub_departments = new List<DepartmentItem>();

                int department_id = 1;
                department_repository.setup(x => x.get_departments_by_id(department_id)).Return(department);
                department_repository.setup(x => x.get_the_sub_departments(department)).Return(the_sub_departments);
            };

        Because b = () => sut.process(request);

        It should_display_the_sub_departements_of_a_main_dpearment_ = () => report_engine.received(x => x.display(the_sub_departments));           
        
        static IFindDepartments department_repository ;
        static IDisplayReports report_engine;
        static IProvideDetailsToCommands request;
        static DepartmentItem department;
        static IEnumerable<DepartmentItem> the_sub_departments;
    }
  }
}
