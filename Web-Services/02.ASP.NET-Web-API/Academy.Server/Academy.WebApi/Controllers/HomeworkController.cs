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

    public class HomeworksController : ApiController
    {
        private readonly IAcademyData data;

        public HomeworksController()
            : this(new AcademyData())
        {
        }

        public HomeworksController(IAcademyData data)
        {
            this.data = data;
        }

        // GET api/homeworks/all
        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data
                .Homeworks
                .All()
                .Select(HomeworkModel.FromHomework);

            return this.Ok(homeworks);
        }

        // GET api/homeworks/byid/5
        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.data
                .Homeworks
                .All()
                .Where(x => x.Id == id)
                .Select(HomeworkModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest("Homework with such id does not exist!");
            }

            return this.Ok(homework);
        }

        // POST api/homeworks/create
        [HttpPost]
        public IHttpActionResult Create(Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = data.Students.All().FirstOrDefault(x => x.Id == homework.StudentId);
            if (student == null)
            {
                return this.BadRequest("Student with such id does not exist!");
            }

            var courseId = homework.CourseId;
            var course = data.Courses.All().FirstOrDefault(x => x.Id == courseId);
            if (course == null)
            {
                return this.BadRequest("Course with such id does not exist!");
            }

            this.data.Homeworks.Add(homework);
            this.data.SaveChanges();

            var hwModel = new HomeworkModel() {
                Id = homework.Id,
                TimeSent = homework.TimeSent,
                Course = homework.Course.Name,
                Student = homework.Student.FirstName + " " + homework.Student.LastName
            };

            return this.CreatedAtRoute("DefaultApi", new { id = homework.Id }, hwModel);    
        }

        // PUT api/homeworks/update/5
        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHomework = this.data.Homeworks.All().FirstOrDefault(x => x.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Homework with such id does not exist!");
            }

            if (homeworkModel.TimeSent != null)
            {
                existingHomework.TimeSent = homeworkModel.TimeSent;
            }   
            
            this.data.SaveChanges();

            homeworkModel.Id = id;
            return this.Ok(homeworkModel);
        }

        // DELETE api/homeworks/delete/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.data.Homeworks.All().FirstOrDefault(x => x.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Homework with such id does not exist!");
            }

            this.data.Homeworks.Delete(existingHomework);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
