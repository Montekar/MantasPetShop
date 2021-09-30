namespace Mantas.PetShop.Core.Filtering
{
    public class Filter
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }

        public string SearchText { get; set; }
    }
}