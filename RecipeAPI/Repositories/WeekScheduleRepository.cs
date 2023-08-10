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

        public WeekSchedule GetWeekScheduleById(int weekScheduleId)
        {
            return _dbContext.WeekSchedules.Find(weekScheduleId);
        }

        public void CreateWeekSchedule(WeekSchedule weekSchedule)
        {
            _dbContext.WeekSchedules.Add(weekSchedule);
            _dbContext.SaveChanges();
        }

        public void UpdateWeekSchedule(WeekSchedule weekSchedule)
        {
            _dbContext.Entry(weekSchedule).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteWeekSchedule(int weekScheduleId)
        {
            WeekSchedule weekSchedule = _dbContext.WeekSchedules.Find(weekScheduleId);
            if (weekSchedule != null)
            {
                _dbContext.WeekSchedules.Remove(weekSchedule);
                _dbContext.SaveChanges();
            }
        }

    }
}
