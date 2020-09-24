using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budjoni.DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<ModelObuce> ModeliNaStanju()
        {
            return _db.ModeliObuce.Where(s => s.VelicineModela.Any(v => v.KolicinaNaStanju > 0)).ToList();
        }
    }
}
