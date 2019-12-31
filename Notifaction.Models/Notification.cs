using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.Models
{
    public class Notification : BaseModel
    {
        public int senderId { get; set; }
        public int receievedId { get; set; }
        public string message { get; set; }
    }
}
