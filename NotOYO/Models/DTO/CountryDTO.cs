using System.ComponentModel.DataAnnotations;

namespace NotOYO.Models.DTO
{
    public class CountryDTO
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
    }
}
