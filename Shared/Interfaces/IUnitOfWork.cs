﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
       bool Commit();
    }
}
