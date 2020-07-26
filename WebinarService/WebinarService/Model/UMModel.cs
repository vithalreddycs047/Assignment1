using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebinarService.Model
{
    public class UMModel
    {
        public partial class UserDetailsDTO
        {
            public decimal Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public decimal? ContactNum { get; set; }
            public DateTime? Dob { get; set; }
            public string Fullname { get; set; }
            public DateTime? CreatedDate { get; set; }
        }
    }
}
