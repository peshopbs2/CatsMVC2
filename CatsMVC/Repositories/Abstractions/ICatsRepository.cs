﻿using CatsMVC.Data.Entities;

namespace CatsMVC.Repositories.Abstractions
{
    public interface ICatsRepository : ICrudRepository<Cat>
    {
    }
}