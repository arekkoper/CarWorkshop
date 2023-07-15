using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarWorkshop.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string type, string massage)
        {
            var notification = new Notification(type, massage);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
