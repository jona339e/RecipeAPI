using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class WeekScheduleRepository : IWeekScheduleRepository
    {
        private readonly DataContext _dbContext;

        public WeekScheduleRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateWeekSchedule(WeekSchedule weekSchedule)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWeekSchedule(WeekSchedule weekSchedule)
        {
            throw new NotImplementedException();
        }

        public WeekSchedule GetWeekScheduleById(int weekScheduleId)
        {
            return _dbContext.WeekSchedules.Find(weekScheduleId);
        }

        public List<WeekSchedule> GetWeekSchedules()
        {
            return _dbContext.WeekSchedules.ToList();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateWeekSchedule(WeekSchedule weekSchedule)
        {
            _dbContext.WeekSchedules.Update(weekSchedule);
            return Save();
        }

        public bool WeekScheduleExists(int weekScheduleId)
        {
            return _dbContext.WeekSchedules.Any(ws => ws.WeekScheduleId == weekScheduleId);
        }
    }
}
