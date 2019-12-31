using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.Models
{
    public class Order : BaseModel
    {
        public patient patient { get; set; }
        public string orderMessage { get; set; }
        public bool accepted { get; set; } = false;
    }
}
