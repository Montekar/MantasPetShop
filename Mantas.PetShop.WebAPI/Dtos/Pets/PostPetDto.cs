namespace Mantas.PetShop.WebAPI.Dtos.Pets
{
    public class PostPetDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int OwnerId { get; set; }
    }
}