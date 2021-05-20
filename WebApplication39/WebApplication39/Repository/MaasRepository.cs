using MongoRepo.Context;
using MongoRepo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication39.Database;
using WebApplication39.Interfaces.Repository;
using WebApplication39.Models;

namespace WebApplication39.Repository
{
    public class MaasRepository : CommonRepository<Maas>, IMaasRepository
    {
        public MaasRepository() : base(new ApplicationDbContext(DbConnection.ConnectionString, DbConnection.DBName))
        {

        }
    }
}
