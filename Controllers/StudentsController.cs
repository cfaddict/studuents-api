using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    public class StudentsController : ControllerBase
    {
        public List<Student> students;

        private readonly TechElevatorContext context;

        public StudentsController() 
        {

        }

        [HttpGet]
        [Route("/students")]
        public ActionResult<List<Student>> ListStudents()
        {
            return students;
        }

        [HttpGet]
        [Route("/students/{id}", Name = "GetStudent")]
        public ActionResult<Student> StudentDetails(int? id)
        {
            var student = context.Students.Find(id);
            if( student == null ) 
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        [Route("/students")]
        public IActionResult Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Students.Add(student);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("/students/{id}")]
        public IActionResult Put(int id, [FromBody] Student student) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Update(student);
            context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("/students/{id}")]
        public IActionResult Delete(int id)
        {
            Student student = context.Students.Find(id);
            if( student == null )
            {
                return NotFound();
            }

            context.Remove(student);
            context.SaveChanges();
            return Ok();
        }

    }
}