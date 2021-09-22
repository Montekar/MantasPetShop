using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _petTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }

        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepository.CreatePetType(petType);
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepository.GetPetTypes().ToList();        }

        public PetType ReadPetType(int id)
        {
            return _petTypeRepository.ReadPetType(id);
        }

        public PetType UpdatePetType(PetType petType)
        {
            return _petTypeRepository.UpdatePetType(petType);
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepository.DeletePetType(id);
        }

        public string GetAvailableTypesString()
        {
            var list = GetPetTypes();
            string types;
            types = "(";
            for (int i = 0; i < list.Capacity; i++)
            {
                if (i < list.Capacity && i+1 !=list.Capacity)
                {
                    types += list[i].Type+ ",";
                }
                else
                {
                    types += list[i].Type;
                }
            }
            types += ")";
            return types;
        }
        
        public PetType Find(string type)
        {
            var list = _petTypeRepository.GetPetTypes();
            var result = list.SingleOrDefault(petType => petType.Type == type);
            
            return result;
        }
    }
}