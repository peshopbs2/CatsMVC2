using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsMVC.DTOs
{
    public class CreateCatVisitDTO : CatVisitDTO
    {
        public List<SelectListItem> Cats { get; set; }
        public List<SelectListItem> Vets { get; set; }
    }
}
