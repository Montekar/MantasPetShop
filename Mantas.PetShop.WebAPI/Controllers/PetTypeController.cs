using System;
using System.Collections.Generic;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.WebAPI.Dtos.Owner;
using Mantas.PetShop.WebAPI.Dtos.PetType;
using Microsoft.AspNetCore.Mvc;

namespace Mantas.PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : Controller
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        
        [HttpGet] 
        public ActionResult<List<PetType>> ReadAll()
        {
            return Ok(_petTypeService.GetPetTypes());
        }
        
        [HttpGet("{id}")] 
        public ActionResult<PetType> ReadById(int id)
        {
            var petType = _petTypeService.ReadPetType(id);
            return Ok(new GetPetTypeByIdDto
            {
                Type = petType.Type
            });
        }
        
        [HttpPost]
        public ActionResult<PetType> CreatePetType([FromBody] PostPetTypeDto dto)
        {
            var petTypeFromDto = new PetType
            {
                Type = dto.Type
            };
            try
            {
                var newPetType = _petTypeService.CreatePetType(petTypeFromDto);
                return Created(
                    $"https://localhost:5001/api/owners/{newPetType.Id}",
                    newPetType);
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
        public ActionResult<PetType> UpdatePetType(int id, [FromBody] PutPetTypeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id in param must be the same as in object");
            }
            return Ok(_petTypeService.UpdatePetType(new PetType
            {
                Id = id,
                Type = dto.Type
            }));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<PetType> DeletePetType(int id)
        {
            return Ok(_petTypeService.DeletePetType(id));
        }
        
    }
}