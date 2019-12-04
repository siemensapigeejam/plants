using DESPortal.Core.Models;
using DESPortal.Core.Services;
using DESPortal.Infrastructure.DataAccess.DESPortal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESPortal.Infrastructure.Services
{
    public class PlantService : IPlantService
    {
        private readonly DESPortalDBContext _db;

        public PlantService(DESPortalDBContext db)
        {
            _db = db;
        }

        public List<Plant> GetAll()
        {
            return _db.Plants
                .ToList();
        }

        public List<Plant> Filter(List<int> ids)
        {
            return _db.Plants.Where(x => ids.Contains(x.Id)).ToList();
        }

        public List<Plant> Search(string keyword, int skip = 0, int top = 10)
        {
            keyword = keyword.ToLower();
            keyword = keyword.Trim();
            return _db.Plants
                .Where(x => x.Name.ToLower().Contains(keyword))
                .Skip(skip)
                .Take(top)
                .ToList();
        }

        public List<int> SearchInList(string keyword, List<int> ids)
        {
            keyword = keyword.ToLower();
            keyword = keyword.Trim();
            return _db.Plants
                .Where(x => x.Name.ToLower().Contains(keyword)
                    && ids.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();
        }

        public Plant GetById(int id)
        {
            var item = _db.Plants.Find(id);
            return item;
        }

        public void Delete(int id)
        {
            var item = _db.Plants.Find(id);
            if (item != null)
            {
                _db.Plants.Remove(item);
                _db.SaveChanges();
            }
        }


    }
}
