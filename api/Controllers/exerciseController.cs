using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using MySql.Data.MySqlClient;
using PA4DWelchel.Models;

namespace PA4DWelchel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class exerciseController : ControllerBase
    {
        // GET: api/exercise
        [HttpGet]
        public List<Exercise> Get()
        {
            ExerciseUtility utility = new ExerciseUtility();
            return utility.GetAllExercise();
        }

        // GET: api/exercise/5
        // [HttpGet("{id}", Name = "Get")]
        // public Exercise Get(string id, string activity, string miles, string date)
        // {
            
        //     ExerciseUtility utility = new ExerciseUtility();
        //     List<Exercise> myExercise = utility.GetAllExercise();
        //     foreach(Exercise exercise in myExercise) {
        //         if(exercise.Id == id) {
        //             return exercise;
        //         }
        //     }
        //     return new Exercise();
        // }

        // POST: api/exercise
        [HttpPost]
        public void Post([FromBody] Exercise value)
        {
            System.Console.WriteLine(value);
        }

        // PUT: api/exercise/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/exercise/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
