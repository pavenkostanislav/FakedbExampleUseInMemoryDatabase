using System.Linq;

namespace TEST.TestContext.Models.View
{
    public class ViewModel : TestModel
    {
        public ViewModel() { }
        public ViewModel(TestModel Companent)
        {
            if (Companent != null)
            {
                this.UserName = new string(Companent.User?.DisplayName?.ToArray());
                this.UserNullName = new string(Companent.UserNull?.DisplayName?.ToArray());
                this.EmployeeName = new string(Companent.Employee?.DisplayName?.ToArray());
                this.EmployeeNullName = new string(Companent.EmployeeNull?.DisplayName?.ToArray());
            }
        }

        public string UserName { get; set; }
        public string UserNullName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNullName { get; set; }
    }
}
