using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IWeekScheduleRepository
    {
        WeekSchedule GetWeekScheduleById(int weekScheduleId);
        List<WeekSchedule> GetWeekSchedules();
        bool WeekScheduleExists(int weekScheduleId);
        bool CreateWeekSchedule(WeekSchedule weekSchedule);
        bool UpdateWeekSchedule(WeekSchedule weekSchedule);
        bool DeleteWeekSchedule(WeekSchedule weekSchedule);
        bool Save();
    }
}
