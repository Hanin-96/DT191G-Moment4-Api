namespace Music_Api.Models
{
    public class Category
    {
        //Properties
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        //Koppla category med soundtrack
        //public List<Soundtrack>? Soundtrack { get; set; }
    }
}
