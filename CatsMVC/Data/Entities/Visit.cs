namespace CatsMVC.Data.Entities
{
    public class Visit
    {
        public int CatId { get; set; }
        public virtual Cat Cat { get; set; }
        public int VetId { get; set; }
        public virtual Vet Vet { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
    }
}
