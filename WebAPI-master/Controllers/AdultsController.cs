using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAcces;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class 
        AdultsController : ControllerBase
    {
        private IFileAdapter FileAdapter;
        //private DBContext _dbContext;
        public AdultsController(IFileAdapter fileAdapter)
        {
            FileAdapter = fileAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IList<Adult> adults = await FileAdapter.GetAdultsAsync();
                //IList<Adult> adults = await _dbContext.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult adult = await FileAdapter.GetAdultAsync(id);
                
                if (adult == null)
                    return NotFound();
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await FileAdapter.AddAdultAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdultAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await FileAdapter.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Adult>> UpdateAdultAsync([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult update = await FileAdapter.UpdateAsync(adult);
                return Ok(update);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}