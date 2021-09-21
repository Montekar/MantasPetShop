using System;
using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.WebAPI.Dtos.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Mantas.PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpGet] 
        public ActionResult<List<RaedAllPetDto>> ReadAll()
        {
            var pets = _petService.GetPets().Select(p => new RaedAllPetDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
                
            });
            return Ok(pets);
        }
        
        [HttpGet("{id}")] 
        public ActionResult<Pet> ReadById(int id)
        {
            var pet = _petService.SearchPet(id);
            return Ok(new GetPetByIdDto
            {
                Name = pet.Name,
                Color = pet.Color,
                Price = pet.Price
            });
        }

        [HttpPost]
        public ActionResult<Pet> CreatePet([FromBody] PostPetDto dto)
        {
            var petFromDto = new Pet
            {
                Name = dto.Name,
                Color = dto.Color,
                Price = dto.Price,
                Owner = new Owner
                {
                    Id = dto.OwnerId
                }
            };
            try
            {
                var newPet = _petService.CreatePet(petFromDto);
                return Created(
                    $"https://localhost:5001/api/pets/{newPet.Id}",
                    newPet);
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
        public ActionResult<Pet> UpdatePet(int id, [FromBody] PutPetDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id in param must be the same as in object");
            }
            return Ok(_petService.UpdatePet(new Pet
            {
                Id = id,
                Name = dto.Name,
                Color = dto.Color,
                Price = dto.Price,
                Owner = new Owner
                {
                    Id = dto.OwnerId
                }
            }));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Pet> DeletePet(int id)
        {
            return Ok(_petService.DeletePet(id));
        }
    }
}