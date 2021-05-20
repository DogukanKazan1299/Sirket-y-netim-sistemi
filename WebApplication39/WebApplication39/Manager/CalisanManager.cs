﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoRepo.Manager;
using WebApplication39.Models;
using WebApplication39.Interfaces.Manager;
using WebApplication39.Repository;

namespace WebApplication39.Manager
{
    public class CalisanManager:CommonManager<Calisan> , ICalisanManager
    {
        public CalisanManager() : base(new CalisanRepository())
        {

        }
    }
}
