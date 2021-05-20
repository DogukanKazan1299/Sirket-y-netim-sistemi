﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoRepo.Repository;
using WebApplication39.Models;
using MongoRepo.Context;
using WebApplication39.Interfaces.Repository;
using WebApplication39.Database;
namespace WebApplication39.Repository
{
    public class RaporlarRepository : CommonRepository<Raporlar>, IRaporlarRepository
    {
        public RaporlarRepository() : base(new ApplicationDbContext(DbConnection.ConnectionString, DbConnection.DBName))
        {

        }
    }
}
