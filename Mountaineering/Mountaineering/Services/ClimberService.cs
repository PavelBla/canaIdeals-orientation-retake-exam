using Microsoft.EntityFrameworkCore;
using Mountaineering.Database;
using Mountaineering.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Services
{
    public class ClimberService
    {
        private ApplicationDbContext DbContext { get; }
        public ClimberService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<Climber> FindAllClimbers()
        {
            return DbContext.Climbers.Include(x => x.Mountain).ToList();
        }
        public Climber FindClimberById(long id)
        {
            return DbContext.Climbers.Include(x => x.Mountain).FirstOrDefault(x => x.Id == id);
        }
        public List<Mountain> FindAllMontains()
        {
            return DbContext.Mountains.Include(x => x.CurrClimbers).ToList();
        }
        public Mountain FindMountainById(long id)
        {
            return DbContext.Mountains.Include(x => x.CurrClimbers).FirstOrDefault(x => x.Id == id);
        }
        public long FindMountainByName(string name)
        {
            return DbContext.Mountains.FirstOrDefault(x => x.Name == name).Id;
        }

        public void AddNewClimber(string name, string nation, string mountain)
        {
            DbContext.Climbers.Add(new Climber() { Name = name, Nation = nation, IsInjured = false, CurrentAltitude = 0, MountainId = FindMountainByName(mountain) });
            DbContext.SaveChanges();
        }
        public void Update(Climber climber)
        {
            DbContext.Update(climber);
            DbContext.SaveChanges();
        }
        public void Rescue(long id)
        {
            var climber = FindClimberById(id);
            climber.CurrentAltitude = 0;
            Update(climber);
        }
        public void AddAltitude(string name, int altitude)
        {
        }
       
    }
}
