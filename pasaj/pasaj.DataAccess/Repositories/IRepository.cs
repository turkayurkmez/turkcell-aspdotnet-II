﻿using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);

    }
}
