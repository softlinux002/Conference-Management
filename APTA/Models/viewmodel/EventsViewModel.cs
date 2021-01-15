using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APTA.Models.viewmodel
{
    public class EventsViewModel
    {
        public int EVENT_ID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ORGANISER { get; set; }
        public string CENTER { get; set; }
    }
}