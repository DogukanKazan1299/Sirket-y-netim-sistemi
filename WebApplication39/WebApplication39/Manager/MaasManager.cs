using MongoRepo.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication39.Interfaces.Manager;
using WebApplication39.Models;
using WebApplication39.Repository;

namespace WebApplication39.Manager
{
    public class MaasManager : CommonManager<Maas>, IMaasManager
    {
        public MaasManager() : base(new MaasRepository())
        {

        }
    }
}
