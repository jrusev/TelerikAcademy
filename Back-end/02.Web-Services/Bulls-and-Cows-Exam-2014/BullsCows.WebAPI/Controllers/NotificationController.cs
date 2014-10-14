using BullsCows.Data;
using System.Linq;
using System.Web.Http;

using Microsoft.AspNet.Identity;


namespace BullsCows.WebAPI.Controllers
{
    public class NotificationsController : BaseApiController
    {
        const int defaultPageSize = 10;

        public NotificationsController()
            : base(new BullsCowsData())
        {
        }

        public NotificationsController(IBullsCowsData data)
            : base(data)
        {
        }

        // GET api/Notifications
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        // GET api/Notifications?page=P
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.data.Users.Find(userId);

            var notfications = user.Notifications
                .OrderBy(n => n.DateCreated)
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);
            return Ok(notfications);
        }
    }
}
