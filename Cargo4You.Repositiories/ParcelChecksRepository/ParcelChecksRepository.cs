﻿using Cargo4You.Models;
using Cargo4You.Models.Entities;

namespace Cargo4You.Repositiories
{
    public class ParcelChecksRepository : BaseRepository<ParcelChecks>, IParcelChecksRepository
    {
        public ParcelChecksRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
