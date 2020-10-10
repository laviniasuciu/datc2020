using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace L02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return StudentRepo.getAll();
        }

        [HttpGet("{id}")]
        public Student GetStudentsbyId([FromRoute] int id)
        {
            return StudentRepo.getById(id);
        }

        [HttpPost]
        public string CreateStudent([FromBody] Student student)
        {
            try
            {
                Console.WriteLine(student.ToString());
                StudentRepo.insert(student);
                return "Student created successfully";
            }
            catch (System.Exception error)
            {
                return "Eroare: " + error.Message;
                throw;
            }
        }

        [HttpPut("{id}")]
        public string UpdateStudent([FromRoute] int id, [FromBody] Student student)
        {
            Student updatedStudent = StudentRepo.update(id, student);
            return updatedStudent.ToString();
        }

        [HttpDelete("{id}")]
        public string DeleteStudentById([FromRoute] int id)
        {
            StudentRepo.deleteById(id);
            return "Student removed successfully";
        }
    }
}
