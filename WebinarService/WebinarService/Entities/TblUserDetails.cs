using System;
using System.Collections.Generic;

namespace WebinarService.Entities
{
    public partial class TblUserDetails
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal? ContactNum { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
