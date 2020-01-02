using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notifaction.API.DTO;
using Notifaction.BL.Contract;
using Notifaction.Models;

namespace Notifaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderService.GetAll().Include(x => x.patient).ToList());
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            var data = _orderService.Get(id);
            if (data == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(data);
            }
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] orderDTO orderDTO)
        {
            var value = _mapper.Map<Order>(orderDTO);
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
        [HttpPost("Put/{id}")]
        public IActionResult Put(int id, [FromBody] orderDTO orderDTO)
        {
            Order value = new Order();
            var valuea = _mapper.Map<Order>(orderDTO);
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
        [HttpPost("Delete/{id}")]
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
