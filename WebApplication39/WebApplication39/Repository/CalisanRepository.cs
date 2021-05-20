using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoRepo.Context;
using MongoRepo.Repository;
using WebApplication39.Models;
using WebApplication39.Interfaces.Repository;
using WebApplication39.Database;

namespace WebApplication39.Repository
{
    public class CalisanRepository : CommonRepository<Calisan>, ICalisanRepository
    {
        public CalisanRepository() : base(new ApplicationDbContext(DbConnection.ConnectionString, DbConnection.DBName))
        {



        }
    }
}
