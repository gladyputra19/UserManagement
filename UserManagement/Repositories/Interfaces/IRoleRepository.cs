﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Get();
        Role Get(string Id);
    }
}
