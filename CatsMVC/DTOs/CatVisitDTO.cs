﻿namespace CatsMVC.DTOs
{
    public class CatVisitDTO
    {
        public int CatId { get; set; }
        public int VetId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }
    }
}
