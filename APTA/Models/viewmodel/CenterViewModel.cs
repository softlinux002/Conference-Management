using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APTA.Models.viewmodel
{
    public class CenterViewModel
    {
        public int LocationID { get; set; }
        public string Location { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}