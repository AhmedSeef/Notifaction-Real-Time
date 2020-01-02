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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        // GET: api/Patient
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patientService.GetAll().ToList());
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult Get(int id)
        {
            return Ok(_patientService.Get(id));
        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult Post([FromBody] Patient value)
        {
            try
            {
                _patientService.AddOrUpdate(value);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT: api/Patient/5
        [HttpPost("Put/{id}")]
        public IActionResult Put(int id, [FromBody] Patient value)
        {
            try
            {
                _patientService.AddOrUpdate(value);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _patientService.Remove(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
