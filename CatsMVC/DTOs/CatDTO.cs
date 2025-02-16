using System.ComponentModel.DataAnnotations;

namespace CatsMVC.DTOs
{
    public class CatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Breed { get; set; }
        [Display(Name="Image")]
        public string ImageUrl { get; set; }
        public ICollection<CatVisitDTO>? Visits { get; set; }
    }
}
