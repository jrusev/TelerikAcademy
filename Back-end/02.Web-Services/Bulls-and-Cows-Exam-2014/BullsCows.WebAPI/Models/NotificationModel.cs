using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BullsCows.Models;

namespace BullsCows.WebAPI.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public NotificationState State { get; set; }

        public int GameId { get; set; }
    }
}