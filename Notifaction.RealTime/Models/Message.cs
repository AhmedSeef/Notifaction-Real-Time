using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Notifaction.RealTime.Models
{
    [Serializable]
    [DataContract]
    public class Message
    {
        public string clientuniqueid { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public string? toUserId { get; set; }
    }
}
