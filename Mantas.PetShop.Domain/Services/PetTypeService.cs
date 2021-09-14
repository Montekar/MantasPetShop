using System.Collections.Generic;
using System.Linq;
using Mantas.PetShop.Core.IServices;
using Mantas.PetShop.Core.Models;
using Mantas.PetShop.Domain.IRepositories;

namespace Mantas.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepo;

        public PetTypeService(IPetTypeRepository petTypeRepo)
        {
            _petTypeRepo = petTypeRepo;
        }

        public PetType Find(string type)
        {
            var list = _petTypeRepo.GetPetTypes();
            var result = list.SingleOrDefault(petType => petType.Name == type);
            
            return result;
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepo.GetPetTypes().ToList();        }

        public string GetAvailableTypesString()
        {
            var list = GetPetTypes();
            string types;
            types = "(";
            for (int i = 0; i < list.Capacity; i++)
            {
                if (i < list.Capacity && i+1 !=list.Capacity)
                {
                    types += list[i].Name+ ",";
                }
                else
                {
                    types += list[i].Name;
                }
            }
            types += ")";
            return types;
        }
    }
}