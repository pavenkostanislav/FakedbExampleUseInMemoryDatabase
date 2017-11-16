using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST.TestContext.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }

        [Key]
        public int Id { get; set; }

        public string DisplayName { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }


        public void ClearVirtualProperties()
        {
        }
    }
}
