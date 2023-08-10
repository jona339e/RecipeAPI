using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class WeekSchedule
    {
        [Key]
        public int WeekScheduleId { get; set; }

        public DateTime DayAndTime { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }

}
