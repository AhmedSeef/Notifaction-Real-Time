using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifaction.BL.Contract;
using Notifaction.Models;

namespace Notifaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderService.GetAll().ToList());
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            var data = _orderService.Get(id);
            return Ok(data);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order value)
        {
            try
            {
                _orderService.AddOrUpdate(value);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // PUT: api/Order/5
        [HttpPut("Put/{id}")]
        public IActionResult Put(int id, [FromBody] Order value)
        {
            try
            {
                _orderService.AddOrUpdate(value);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.Remove(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
