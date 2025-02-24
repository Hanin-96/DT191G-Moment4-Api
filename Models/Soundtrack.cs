using System.ComponentModel.DataAnnotations;

namespace Music_Api.Models
{
    public class Soundtrack
    {
        //Properties
        public int SoundtrackId { get; set; }
        [Required(ErrorMessage = "Fyll i Artistnamn")]
        public string? Artist { get; set; }
        [Required(ErrorMessage = "Fyll i låttitel")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Fyll i spellängden i sekunder")]
        public int Length { get; set; }

        //Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
