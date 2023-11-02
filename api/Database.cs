using PA4DWelchel;
using MySql.Data.MySqlClient;


namespace PA4DWelchel

{
    public class Database
    {
         private string host {get; set;}
        private string database {get; set;}

        private string username {get; set;}
        private string port {get; set;}
        private string password {get; set;}

        public string cs {get; set;}
        

        public Database() {
            host = "l6glqt8gsx37y4hs.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            database = "muoflfscuq8psk40";
            username = "tjcswwuyov8obkm1";
            port = "3306";
            password = "eb0meohb8unn6eco";
            cs = $"server={host};user={username};database={database};port={port};password={password}";

        }
    }
}