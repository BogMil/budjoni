using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budjoni.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Budjoni.DAL
{
    public class ModelService
    {
        private readonly ApplicationDbContext _db;
        public ModelService(ApplicationDbContext Db)
        {
            _db = Db;
        }

        public void Create(Model model)
        {
            _db.Modeli.Add(model);
            _db.SaveChanges();
        }

        public List<Model> ModeliNaStanju()
        {
            return _db.Modeli.Where(s => s.BojeModela.Any(v => v.VelicineModela.Any(d=>d.KolicinaNaStanju > 0))).ToList();
        }

        public List<Model> All()
        {
            return _db.Modeli.ToList();
        }

        public BojaModela GetNovaBojaModela()
        {
            return new BojaModela() {VelicineModela = new List<VelicinaModela>()};
        }
    }
}
