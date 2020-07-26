using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebinarService.Entities;
using WebinarService.Model;
using static WebinarService.Model.UMModel;

namespace WebinarService.Controllers.Service
{
    public interface IWebinarServices
    {
        string SimpleFetchCall();
        UserDetailsDTO UserDetails(UserDetailsDTO userDetails);
        List<UserDetailsDTO> GetUserdetails(int Id);
        List<UserDTO> GetUsers();
        List<ActivityPeriods> GetuserdataById(string id);
        List<ActivityPeriods> GetuserdataByDate(string id, DateTime activedate);
    }

    public class WebinarServices : IWebinarServices
    {
        private IMapper _mapper;
        private WebinarUMContext _context;
        public WebinarServices(IMapper mapper, WebinarUMContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public string SimpleFetchCall()
        {
            return "Simple fetch call response";
        }

        public UserDetailsDTO UserDetails(UserDetailsDTO userDetails)
        {
            var data = _mapper.Map<TblUserDetails>(userDetails);
            _context.TblUserDetails.Add(data);
            _context.SaveChanges();

            var result = _mapper.Map<UserDetailsDTO>(data);
            return result;

        }
        public List<UserDetailsDTO> GetUserdetails(int Id)
        {
            var data = _context.TblUserDetails.Select(a => a);
            var result = _mapper.Map<List<UserDetailsDTO>>(data);

            foreach (var item in result)
            {
                item.Fullname = item.FirstName + item.MiddleName + " " + item.LastName;
            }
            return result;
        }
        public List<UserDTO> GetUsers()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Test JSON\TestJSON.json";
            var JSON = File.ReadAllText(filePath);
            //dynamic myJObject = JObject.Parse(filePath1).Last;
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var item in jsonObj["members"])
            {
                var userDTO = new UserDTO()
                {
                    id = item["id"],
                    real_name = item["real_name"],
                };
                userDTOs.Add(userDTO);
                
            }
           
            return userDTOs;
        }
        public List<ActivityPeriods> GetuserdataById(string id)
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Test JSON\TestJSON.json";
            var JSON = File.ReadAllText(filePath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            List<UserDTO> jsonarr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(jsonObj["members"].ToString());
            var jsondata = jsonarr.Where(a => a.id == id).ToList();

            ActivityPeriods periods = new ActivityPeriods();
            List<ActivityPeriods> activeperiods = new List<ActivityPeriods>();
            foreach (var item in jsondata)
            {
              activeperiods =  item.activity_periods;
            } 
            return activeperiods;
        }
        public List<ActivityPeriods> GetuserdataByDate(string id,DateTime activedate)
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Test JSON\TestJSON.json";
            var JSON = File.ReadAllText(filePath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            List<UserDTO>  jsonarr = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(jsonObj["members"].ToString());
            var jsondata = jsonarr.Where(a=>a.id== id).ToList();
            ActivityPeriods periods = new ActivityPeriods();
            List<ActivityPeriods> activeperiods = new List<ActivityPeriods>();
            foreach (var item in jsondata)
            {
                foreach (var item2 in item.activity_periods)
                {
                   var startdateonly=Convert.ToDateTime(item2.start_time).Date;
                    var enddateonly = Convert.ToDateTime(item2.end_time).Date;

                    if (startdateonly <= activedate && activedate<=enddateonly)
                    {
                        periods.start_time = item2.start_time;
                        periods.end_time = item2.end_time;
                        activeperiods.Add(periods);
                    }
                }
            }
              return activeperiods;
        }
    }
}


