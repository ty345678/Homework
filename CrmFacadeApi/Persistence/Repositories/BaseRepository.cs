﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmFacadeApi.Persistence.Contexts;

namespace CrmFacadeApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
         
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    
    }
}
