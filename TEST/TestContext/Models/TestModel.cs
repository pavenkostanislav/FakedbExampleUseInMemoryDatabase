using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.TestContext.Models
{
    [Table("TableModelTest", Schema = "dbo")]
    public class TestModel
    {
        public string Test { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateNull { get; set; }
        public int UserId { get; set; }
        public int? UserNullId { get; set; }
        public int EmployeeId { get; set; }
        public int? EmployeeNullId { get; set; }
        public bool IsBool { get; set; }
        public bool? IsBoolNull { get; set; }
        public decimal Decimal { get; set; }
        public decimal? DecimalNull { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("UserNullId")]
        public User UserNull { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("EmployeeNullId")]
        public Employee EmployeeNull { get; set; }


        [Key]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }


        public void ClearVirtualProperties()
        {
            this.User = null;
            this.UserNull = null;
            this.Employee = null;
            this.EmployeeNull = null;
        }
    }
}
