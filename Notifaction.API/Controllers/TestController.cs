using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifaction.API.SignalrHubs;

namespace Notifaction.API.Controllers
{
    [Serializable]
    [DataContract]
    public class CommonData
    {
        [DataMember]
        public string Message { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public static CommonData commonData = new CommonData() { Message = "Our first data" };

        [HttpGet]
        public CommonData Get()
        {
            return commonData;
        }


        [HttpPost]
        public bool Post([FromBody] CommonData data)
        {
            // publish the update to SignalR Hub
            Notifaction.API.SignalrHubs.TestSignalRHub.BroadcastCommonDataStatic(data);
            return true;
        }

    }
}