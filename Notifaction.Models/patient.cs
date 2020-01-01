using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.Models
{
    public class Patient : BaseModel
    {
        public string fName { get; set; }
        public string lName { get; set; }
    }
}
