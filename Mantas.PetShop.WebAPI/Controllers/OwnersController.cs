using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.WebAPI.Dtos.Owner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantas.PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        
        [HttpGet] 
        public ActionResult<List<Owner>> ReadAll()
        {
            return Ok(_ownerService.GetOwners());
        }
        
        [HttpGet("{id}")] 
        public ActionResult<Owner> ReadById(int id)
        {
            var owner = _ownerService.ReadOwner(id);
            return Ok(new GetOwnerByIdDto
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email
            });
        }
        
        [HttpPost]
        public ActionResult<Owner> CreateOwner([FromBody] PostOwnerDto dto)
        {
            var ownerFromDto = new Owner
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };
            try
            {
                var newOwner = _ownerService.CreateOwner(ownerFromDto);
                return Created(
                    $"https://localhost:5001/api/owners/{newOwner.Id}",
                    newOwner);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwner(int id, [FromBody] PutOwnerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id in param must be the same as in object");
            }
            return Ok(_ownerService.UpdateOwner(new Owner
            {
                Id = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            }));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Owner> DeleteOwner(int id)
        {
            return Ok(_ownerService.DeleteOwner(id));
        }
        
    }
}