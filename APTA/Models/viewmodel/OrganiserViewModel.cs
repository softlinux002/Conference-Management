using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APTA.Models.viewmodel
{
    public class OrganiserViewModel
    {
        public int ORGANISER_ID { get; set; }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string EVENTS { get; set; }
    }
}