using System.Collections.Generic;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mantas.PetShop.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpGet] 
        public List<Pet> ReadAll()
        {
            return _petService.GetPets();
        }
        
        [HttpGet("{id}")] 
        public List<Pet> ReadById(int id)
        {
            return null;
            //return _petService.GetPets();
        }

        [HttpPost]
        public Pet CreatePet(Pet pet)
        {
            if (pet == null)
            {
                return null;
            }

            return _petService.CreatePet(pet);
        }
        
        [HttpPut("{id}")]
        public Pet UpdatePet(int id, Pet pet)
        {
            return null;
        }
        
        [HttpDelete("{id}")]
        public Pet DeletePet(int id, Pet pet)
        {
            return null;
        }
    }
}