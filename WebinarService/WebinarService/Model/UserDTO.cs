using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebinarService.Model
{
    public class UserDTO
    {
        public UserDTO()
        {
            activity_periods = new List<ActivityPeriods>();
        }
        public string id { get; set; }
        public string real_name { get; set; }
        public string tz { get; set; }
        public List<ActivityPeriods> activity_periods { get; set; }
    }
    public class ActivityPeriods
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
    }
   
}
