using HelloWorldAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello World!";
        //}
        #region PatientList
        private static List<Patient> patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,

                    Name = "Ravi",
                    Age = 25,
                    Gender = "Male",
                    City = "Bangalore"
                },

                new Patient
                {
                    Id = 2,
                    Name = "Hameed",
                    Age = 30,
                    Gender = "Male",
                    City = "Chennai"
                },
                 new Patient
                {
                    Id = 3,
                    Name = "Renjith",
                    Age = 36,
                    Gender = "Male",
                    City = "Kerala"
                },
                  new Patient
                {
                    Id = 4,
                    Name = "Fathima",
                    Age = 25,
                    Gender = "FeMale",
                   City = "Hyderabad"
                },
                      new Patient
                {
                    Id = 5,
                    Name = "Sonu",
                    Age = 25,
                    Gender = "FeMale",
                   City = "Kadapa"
                },
                             new Patient
                {
                    Id = 6,
                    Name = "Sushma",
                    Age = 25,
                    Gender = "FeMale",
                   City = "Badvel"
                },


            };
        #endregion

        #region GETAPI
        [HttpGet]
        public IActionResult GetPatients()
        {
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        #endregion 
        #region PostAPI
        [HttpPost]
        public IActionResult RegisterPatient(Patient patient)
        {
            patient.Id = patients.Count + 1;

            patients.Add(patient);

            return Ok(patient);
        }
        #endregion
        #region PUTAPI
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.Name = updatedPatient.Name;
            patient.Age = updatedPatient.Age;
            patient.Gender = updatedPatient.Gender;
            patient.City = updatedPatient.City;

            return Ok(patient);
        }
        #endregion
        #region PATCHAPI
        [HttpPatch("{id}")]
        public IActionResult PatchPatient(int id, [FromBody] PatchPatientRequest? updates)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            if (updates == null ||
                (updates.Name == null &&
                 !updates.Age.HasValue &&
                 updates.Gender == null &&
                 updates.City == null))
            {
                return BadRequest("Provide at least one patient field to update.");
            }

            if (updates.Name != null)
            {
                patient.Name = updates.Name;
            }

            if (updates.Age.HasValue)
            {
                patient.Age = updates.Age.Value;
            }

            if (updates.Gender != null)
            {
                patient.Gender = updates.Gender;
            }

            if (updates.City != null)
            {
                patient.City = updates.City;
            }

            return Ok(patient);
        }
        #endregion
        #region DELETEAPI
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            patients.Remove(patient);

            for (var index = 0; index < patients.Count; index++)
            {
                patients[index].Id = index + 1;
            }

            return Ok("Patient removed successfully");
        }
        #endregion

    }
}
