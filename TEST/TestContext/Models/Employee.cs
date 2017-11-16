using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.TestContext.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        public string Name { get; set; }


        [Key]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
