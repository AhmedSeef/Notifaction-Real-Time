using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifaction.API.DTO
{
    public class orderDTO
    {
        public int patientId { get; set; }
        public string orderMessage { get; set; }
        public byte? accepted { get; set; } = 0;
    }
}
