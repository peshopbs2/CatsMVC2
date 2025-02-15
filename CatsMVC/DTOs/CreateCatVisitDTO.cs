using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsMVC.DTOs
{
    public class CreateCatVisitDTO
    {
        public int CatId { get; set; }
        public int VetId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }

        public List<SelectListItem> Cats { get; set; }
        public List<SelectListItem> Vets { get; set; }
    }
}
