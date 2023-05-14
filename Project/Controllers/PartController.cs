using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartController : ControllerBase
    {
        private PartService partService { get; set; }

        public PartController(PartService partService)
        {
            this.partService = partService;
        }

        [HttpGet("/get-all")]
        [AllowAnonymous]
        public ActionResult<List<Part>> GetAll()
        {
            try
            {
                var results = partService.GetAll();
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred while retrieving the parts: " + exception.Message);
                return BadRequest("An error occurred while retrieving the parts" +exception.Message);
            }
        }

        [HttpGet("/get/{partId}")]
        [AllowAnonymous]
        public ActionResult<Part> GetById(int partId)
        {
            try
            {
                var part = partService.GetById(partId);
                return Ok();
            }
            catch(Exception exception)
            {
                Console.WriteLine("An error occurred while retrieving the part: " + exception.Message);
                return BadRequest("An error occurred while retrieving the part");
            }
        }

        [HttpPost("/add-part")]
        [Authorize]
        public ActionResult AddPart(AddPartDto payload)
        {
            try
            {
                partService.AddPart(payload);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest("An error occurred while adding the part.");
            }
        }

        [HttpPatch("/edit-part")]
        [Authorize]
        public ActionResult<bool> GetById([FromBody] EditPartDto payload)
        {
            var result = partService.EditPartDetails(payload);

            if (!result)
            {
                return BadRequest("Part could not be updated.");
            }

            return result;
        }

        [HttpDelete("/delete-part")]
        [Authorize]
        public ActionResult<bool> Deletepart(int partId)
        {
            var result = partService.DeletePart(partId);
            if (!result)
            {
                return BadRequest("Part could not be deleted.");
            }

            return result;
        }
    }
}
