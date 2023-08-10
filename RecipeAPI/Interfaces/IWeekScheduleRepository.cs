using RecipeAPI.Models;

namespace RecipeAPI.Interfaces
{
    public interface IWeekScheduleRepository
    {
        WeekSchedule GetWeekScheduleById(int weekScheduleId);
        void CreateWeekSchedule(WeekSchedule weekSchedule);
        void UpdateWeekSchedule(WeekSchedule weekSchedule);
        void DeleteWeekSchedule(int weekScheduleId);
    }
}
