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

        public void Update(Model model)
        {
            _db.Modeli.Update(model);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = Find(id);
            _db.Modeli.Remove(model);
            _db.SaveChanges();
        }

        public List<Model> ModeliNaStanju()
        {
            return _db.Modeli
                .Where(s => s.BojeModela.Any(v => v.VelicineModela.Any(d=>d.KolicinaNaStanju > 0))).ToList();
        }

        public List<Model> All()
        {
            return _db.Modeli.ToList();
        }


        public Model Find(int id)
        {
            return _db.Modeli
                .Include(x=>x.BojeModela)
                .ThenInclude(x=>x.VelicineModela)
                .FirstOrDefault(x => x.Id==id);
        }

        public List<Model> PretraziPoNazivuIliSifri(string textPretrage)
        {
            return _db.Modeli.Where(x => x.NazivModela.Contains(textPretrage) || x.Sifra.Contains(textPretrage)).ToList();
        }

        public List<Model> PretraziModeleNaStanjuPoNazivuIliSifri(string textPretrage)
        {
            return ModeliNaStanju().Where(x => x.NazivModela.Contains(textPretrage) || x.Sifra.Contains(textPretrage)).ToList();
        }

        public BojaModela GetNovaBojaModela()
        {
            return new BojaModela()
            {
                VelicineModela = new List<VelicinaModela>()
                    {
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "36"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "37"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "38"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "39"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "40"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "41"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "43"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "44"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "45"},
                new VelicinaModela(){KolicinaNaStanju = 0,Velicina = "46"},

                }
            };
        }

        public static Model GetNewModel()
        {
            return new Model()
            {
                BojeModela = new List<BojaModela>()
            };
        }
    }
}
