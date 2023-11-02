using PA4DWelchel;
using MySql.Data.MySqlClient;
using PA4DWelchel.Models;


namespace PA4DWelchel
{
    public class ExerciseUtility
    {
        public Database db;

        public ExerciseUtility()
        {
            db = new Database();
        }

        public List<Exercise> GetAllExercise()
        {
            List<Exercise> myExercise = new List<Exercise>();

            using (MySqlConnection con = new MySqlConnection(db.cs))
            {
                con.Open();
                string stm = "SELECT * from exercise ORDER BY date asc";
                using (MySqlCommand cmd = new MySqlCommand(stm, con))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string id = rdr.GetString(0);
                            string activity = rdr.GetString(1);
                            string miles = rdr.GetString(2);
                            string date = rdr.GetString(3);

                            myExercise.Add(new Exercise(id, activity, miles, date));
                        }
                    }
                }
            }

            return myExercise;
        }
    }
}