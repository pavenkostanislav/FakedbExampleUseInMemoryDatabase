using System;

namespace TEST.TestContext.Models.Find
{
    public class FindModel : TestModel
    {
        public DateTime? CreatedDateStart { get; set; }
        public DateTime? CreatedDateEnd { get; set; }

        public DateTime? LastUpdatedDateStart { get; set; }
        public DateTime? LastUpdatedDateEnd { get; set; }


        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public DateTime? DateNullStart { get; set; }
        public DateTime? DateNullEnd { get; set; }
    }
}
