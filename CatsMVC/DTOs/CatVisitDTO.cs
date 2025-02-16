using System.ComponentModel.DataAnnotations;

namespace CatsMVC.DTOs
{
    public class CatVisitDTO
    {
        public int CatId { get; set; }
        public CatDTO? Cat { get; set; }
        public int VetId { get; set; }
        public VetDTO? Vet { get; set; }
        [Display(Name ="Visit date")]
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
    }
}
