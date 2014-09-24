namespace BugLogger.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Net;
    using System.Net.Http;

    using BugLogger.Data;
    using BugLogger.Models;
    using BugLogger.WebAPI.Models;

    public class BugsController : ApiController
    {
        private readonly IBugLoggerData data;

        public BugsController()
            : this(new BugLoggerData())
        {
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        // GET api/bugs
        public IHttpActionResult Get()
        {
            var bugs = this.data.Bugs.All().Select(BugModel.FromBug);
            return Ok(bugs);
        }

        // GET api/bugs/5
        public IHttpActionResult Get(int id)
        {
            var bug = this.data.Bugs.Find(id);

            if (bug == null)
            {
                return NotFound();
            }

            return Ok(new BugModel(bug));
        }

        // GET api/bugs?status=pending
        public IHttpActionResult GetByStatus(string status)
        {
            BugStatus bugStatus;
            if (!Enum.TryParse<BugStatus>(status, ignoreCase: true, result: out bugStatus))
            {
                return this.BadRequest(string.Format("Status type '{0}' does not exist!", status));
            }

            var bugs = this.data.Bugs.All().Where(b => b.Status == bugStatus).Select(BugModel.FromBug);
            return Ok(bugs);
        }

        // GET api/bugs?date=22-06-2014
        public IHttpActionResult GetByDate(string date)
        {
            DateTime searchedDate;
            if (!DateTime.TryParse(date, out searchedDate))
            {
                return this.BadRequest("Date is not in the valid format!");
            }

            var buss = this.data.Bugs.All().ToArray();

            var bugs = this.data.Bugs.All().Where(b => b.LogDate >= searchedDate).Select(BugModel.FromBug);
            return this.Ok(bugs);
        }

        // POST api/bugs
        public IHttpActionResult Post(Bug bug)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (string.IsNullOrWhiteSpace(bug.Text))
            {
                return this.BadRequest("Bug text cannot be null or empty!");
            }

            var newBug = new Bug
            {
                LogDate = DateTime.Now,
                Status = BugStatus.Pending,
                Text = bug.Text
            };

            this.data.Bugs.Add(newBug);
            this.data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = newBug.Id }, new BugModel(newBug));
        }

        // PUT api/bugs/5
        public IHttpActionResult Put(int id, string status)
        {
            Bug bug = this.data.Bugs.Find(id);
            if (bug == null)
            {
                return BadRequest("Bug with such id does not exist!");
            }

            BugStatus bugStatus;
            if (!Enum.TryParse<BugStatus>(status, ignoreCase: true, result: out bugStatus))
            {
                return BadRequest(string.Format("Bug status '{0}' does not exist!", status));
            }

            bug.Status = bugStatus;
            this.data.SaveChanges();

            return this.Ok(new BugModel(bug));
        }

        // DELETE api/bugs/5
        public IHttpActionResult Delete(int id)
        {
            Bug bug = this.data.Bugs.Find(id);
            if (bug == null)
            {
                return BadRequest("Bug with such id does not exist!");
            }

            this.data.Bugs.Delete(bug);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}
