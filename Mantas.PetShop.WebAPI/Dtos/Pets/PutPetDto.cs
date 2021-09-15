namespace Mantas.PetShop.WebAPI.Dtos.Pets
{
    public class PutPetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}