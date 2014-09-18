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

    public class CoursesController : ApiController
    {
        private readonly IAcademyData data;

        public CoursesController()
            : this(new AcademyData())
        {
        }

        public CoursesController(IAcademyData data)
        {
            this.data = data;
        }

        // GET api/courses/all
        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data
                .Courses
                .All()
                .Select(CourseModel.FromCourse);

            return this.Ok(courses);
        }

        // GET api/courses/byid/5
        [HttpGet]
        public IHttpActionResult ById(string id)
        {
            var idAsGuid = new Guid(id);
            var course = this.data
                .Courses
                .All()
                .Where(x => x.Id == idAsGuid)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Course does not exist - invalid id");
            }

            return this.Ok(course);
        }

        // POST api/courses/create
        [HttpPost]
        public IHttpActionResult Create(Course course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.data.Courses.Add(course);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // PUT api/courses/update/5
        [HttpPut]
        public IHttpActionResult Update(string id, CourseModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idAsGuid = new Guid(id);
            var existingCourse = this.data.Courses.All().FirstOrDefault(x => x.Id == idAsGuid);
            if (existingCourse == null)
            {
                return BadRequest("Course with such id does not exist!");
            }

            if (!string.IsNullOrWhiteSpace(courseModel.CourseName))
            {
                existingCourse.Name = courseModel.CourseName;
            }   
            
            this.data.SaveChanges();

            courseModel.Id = idAsGuid;
            return this.Ok(courseModel);
        }

        // DELETE api/courses/delete/5
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var idAsGuid = new Guid(id);
            var existingCourse = this.data.Courses.All().FirstOrDefault(x => x.Id == idAsGuid);
            if (existingCourse == null)
            {
                return BadRequest("Course with such id does not exist!");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
