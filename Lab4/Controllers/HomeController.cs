using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String[] list)
        {
            DateTime today = DateTime.Now;
            String month = DateTime.Now.ToString("MMMM");
            DayOfWeek dayofweek = DateTime.Now.DayOfWeek;

            int year = DateTime.Now.Year;
            int day = DateTime.Now.Day;
            String time = today.ToShortTimeString();

            int daysInYear = DateTime.IsLeapYear(today.Year) ? 366 : 365;
            int daysLeftInYear = daysInYear - today.DayOfYear;

            String currentDate = $"The time is {time} on {dayofweek}, {month} {day}, {year}";
            String daysLeft = $"There are {daysLeftInYear} more days in {year}";
            String greeting;

            TimeSpan morning = new TimeSpan(11, 59, 59); //Before noon
            TimeSpan night = new TimeSpan(18, 0, 0); //(evening) after 6
            TimeSpan now = DateTime.Now.TimeOfDay;

            if (DateTime.UtcNow.ToString("tt") == "AM")
            {
                greeting = "Good Morning!";
            }
            else if ((now > morning) && (now < night))
            {
                greeting = "Good Afternoon!";
            }
            else
            {
                greeting = "Good Evening!";
            }

            ViewData["currentDate"] = currentDate;
            ViewData["daysLeft"] = daysLeft;
            ViewData["greeting"] = greeting;

            return View();
        }
        public IActionResult Items()
        {
            String url = HttpContext.Request.Path;
            String newUrl = url.Substring(12);
            String[] listOfStuff = { "C#", "HTML5", "CSS3", "JavaScript" };

            if (newUrl == "")
            {
                int id = 0;
                ViewData["id"] = id;
            }
            else
            {
                int id = Convert.ToInt32(newUrl);
                ViewData["id"] = id;
            }

            return View(listOfStuff);
        }

    }
}
