using RecipeAPI.Models;

namespace RecipeAPI.Dto
{
    public class WeekScheduleDTO
    {
        public int WeekScheduleId { get; set; }
        public DateTime DayAndTime { get; set; }
        public int RecipeId { get; set; }
    }
}

