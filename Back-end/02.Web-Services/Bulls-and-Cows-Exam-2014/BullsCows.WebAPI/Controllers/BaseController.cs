namespace BullsCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BullsCows.Data;

    public class BaseApiController : ApiController
    {
        protected IBullsCowsData data;

        public BaseApiController(IBullsCowsData data)
        {
            this.data = data;
        }
    }
}
