namespace Academy.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Academy.Data;
    using Academy.Models;
    using Academy.WebApi.Models;

    public class StudentsController : ApiController
    {
        private readonly IAcademyData data;

        public StudentsController()
            : this(new AcademyData())
        {
        }

        public StudentsController(IAcademyData data)
        {
            this.data = data;
        }

        // GET api/students/all
        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data
                .Students
                .All()
                .Select(StudentModel.FromStudent);

            return this.Ok(students);
        }

        // GET api/students/byid/5
        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data
                .Students
                .All()
                .Where(s => s.Id == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Student does not exist - invalid id");
            }

            return this.Ok(student);
        }

        // POST api/students/create
        [HttpPost]
        public IHttpActionResult Create(Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Students.Add(student);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        // PUT api/students/update/5
        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Student with such id does not exist!");
            }

            if (!string.IsNullOrWhiteSpace(studentModel.FirstName))
            {
                existingStudent.FirstName = studentModel.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(studentModel.LastName))
            {
                existingStudent.LastName = studentModel.LastName;
            }           
            
            this.data.SaveChanges();

            studentModel.Id = id;
            return this.Ok(studentModel);
        }

        // DELETE api/students/delete/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Student with such id does not exist!");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return this.Ok();
        }

        // POST api/students/addcourse/5
        [HttpPost]
        public IHttpActionResult AddCourse(int id, string courseId)
        {
            var student = this.data.Students.All().FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return this.BadRequest("Student with such id does not exist!");
            }

            var idAsGuid = new Guid(courseId);
            var course = this.data.Courses.All().FirstOrDefault(x => x.Id == idAsGuid);
            if (course == null)
            {
                return this.BadRequest("Course with such id does not exist!");
            }

            student.Courses.Add(course);
            this.data.SaveChanges();

            return this.Ok("Course added.");
        }
    }
}
