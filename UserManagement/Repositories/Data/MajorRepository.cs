﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.ConnectionStrings;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Repositories.Data
{
    public class MajorRepository : GeneralRepository<MajorVM>
    {
        public MajorRepository(ConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
