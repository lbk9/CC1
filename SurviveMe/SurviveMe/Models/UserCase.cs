using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveMe.Models
{
    public class UserCase
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }
        public Guid? BuddyId { get; set; }
        public DateTime CallTime { get; set; }
        public string CallTimeAsString { get; set; }
        public List<string> SelectedIssues { get; set; }
    }
}
