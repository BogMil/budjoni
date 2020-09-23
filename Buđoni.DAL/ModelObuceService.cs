using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Budjoni.DAL.Models;

namespace Budjoni.DAL
{
    public class ModelObuceService
    {
        private readonly ApplicationDbContext _db;
        public ModelObuceService(ApplicationDbContext Db)
        {
            _db = Db;
        }

        public void Create(ModelObuce modelObuce)
        {
            modelObuce.VelicineModela = modelObuce.VelicineModela.Where(s => s.KolicinaNaStanju > 0).ToList();
            _db.ModeliObuce.Add(modelObuce);
            _db.SaveChanges();
        }
    }
}
