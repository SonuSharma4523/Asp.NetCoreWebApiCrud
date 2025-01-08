using Asp.NetCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreWebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly CodeFirstDbContext context;

        public StudentAPIController(CodeFirstDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>>  GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentsById(int id)
        {
            var Student = await context.Students.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }

            return Ok(Student);


        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();

            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);

        }
        [HttpDelete("{id}")] 
        public async Task<ActionResult<List<Student>>> deleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return BadRequest();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }
        //public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        //{
        //    if (id != std.Id)
        //    {
        //        return BadRequest("ID mismatch");
        //    }

        //    // Check if the student exists
        //    var existingStudent = await context.Students.FindAsync(id);
        //    if (existingStudent == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update properties
        //    existingStudent.StudentName = std.StudentName;  
        //    existingStudent.Age = std.Age;
        //    existingStudent.Standard = std.Standard;
        //    existingStudent.StudentGender = std.StudentGender;

        //    // Save changes
        //    await context.SaveChangesAsync();

        //    return Ok(existingStudent);
        //}

    }
}
