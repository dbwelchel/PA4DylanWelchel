using PA4DWelchel;
namespace PA4DWelchel.Models
{
    public class Exercise
    {
        public string Id {get; set;}
        public string Activity {get; set;}

        public string Miles {get; set;}
        public string Date {get; set;}
    
    public Exercise(string id, string activity, string miles, string date)
        {
            Id = id;
            Activity = activity;
            Miles = miles;
            Date = date;
        }
        }
}