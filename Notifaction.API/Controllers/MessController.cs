using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifaction.API.DTO;
using Notifaction.RealTime.DTOs;
using Notifaction.RealTime.Models;
using Notifaction.RealTime.services.contract;

namespace Notifaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessController : ControllerBase
    {
        private readonly IDashboardHostedService _dashboardHostedService;
        public MessController(IDashboardHostedService dashboardHostedService)
        {
            _dashboardHostedService = dashboardHostedService;
        }
        [HttpPost("post")]
        public IActionResult post(Mess mess)
        {
            _dashboardHostedService.DoWork(mess);
            return Ok();
        }

        [HttpPost("SendMs")]
        public IActionResult SendMs(Message mess)
        {
            _dashboardHostedService.GetMs(mess);
            return Ok();
        }
    }
}