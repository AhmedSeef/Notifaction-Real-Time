using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifaction.BL.Contract;

namespace Notifaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notification
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_notificationService.GetAll().ToList());
        }

        // GET: api/Notification/5
        [HttpGet("{id}", Name = "GetNotification")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notification
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Notification/5
        [HttpPut("Put/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
