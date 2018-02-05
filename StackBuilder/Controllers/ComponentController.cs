using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StackBuilder.Models;

namespace StackBuilder.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            var model = new ComponentModel
            {
                AvailableComponent = GetItems()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ComponentModel model)
        {
            if (ModelState.IsValid)
            {
                var components = string.Join(",", model.SelectedComponent);

                // Save data to database, and redirect to Success page.
                TempData["skeleton"] = components;
                TempData.Keep("skeleton");

                //using (System.IO.StreamWriter file =
                //new System.IO.StreamWriter(@"C:\Users\monkos\Source\repos\StackBuilder\StackBuilder\wwwroot\images\WriteLines2.txt", true))
                //{
                //    file.WriteLine(components+"1");
                //}

                return RedirectToAction("Skeleton");
            }
            model.AvailableComponent = GetItems();
            return View(model);
        }
        public ActionResult Skeleton()
        {
            //var skeleton = TempData["skeleton"].ToString();
            //string[] componentList = skeleton.Split(",");

            return View();
        }
        private IList<SelectListItem> GetItems()
        {
            var build = new SelectListGroup() { Name = "build" };
            var orch = new SelectListGroup() { Name = "orchestration" };
            var test = new SelectListGroup() { Name = "test" };
            var mon = new SelectListGroup() { Name = "mon" };
            var log = new SelectListGroup() { Name = "logging" };
            var pub = new SelectListGroup() { Name = "publish" };

            return new List<SelectListItem>
            {
                 //ci/cd
                 new SelectListItem {Text = "GitLab", Value="gitlab", Group = build},
                 new SelectListItem {Text = "Jenkins", Value="jenkins", Group = build},
                 new SelectListItem {Text = "Nexus", Value="nexus", Group = build},
                 // Orchestation
                 new SelectListItem {Text = "StackStorm", Value="stackstorm", Group = orch},
                 new SelectListItem {Text = "SaltStack", Value="saltstack", Group = orch},
                 new SelectListItem {Text = "Rancher", Value="rancher", Group = orch, Disabled = true},
                 new SelectListItem {Text = "Kubernetes", Value="kubernetes", Group = orch, Disabled = true},
                 // Test
                 new SelectListItem {Text = "Selenium", Value="selenium", Group = test, Disabled = true},
                 new SelectListItem {Text = "PyTest", Value="pytest", Group = test, Disabled = true},
                 new SelectListItem {Text = "SonarQube", Value="sonarqube", Group = test, Disabled = true},
                 new SelectListItem {Text = "JUnit", Value="junit", Group = test, Disabled = true},
                 //Monitoring
                 new SelectListItem {Text = "Prometheus", Value="prometheus", Group = mon, Disabled = true},
                 new SelectListItem {Text = "Grafana", Value="grafana", Group = mon, Disabled = true},
                 new SelectListItem {Text = "Kibana", Value="kibana", Group = mon, Disabled = true},
                 new SelectListItem {Text = "Zabbix", Value="zabbix", Group = mon, Disabled = true},
                 //Logging
                 new SelectListItem {Text = "Graylog", Value="graylog", Group = log, Disabled = true},
                 new SelectListItem {Text = "Splunk", Value="splunk", Group = log, Disabled = true},
                 //Publish
                 new SelectListItem {Text = "HAProxy", Value="haproxy", Group = pub, Disabled = true},

            };
        }
    }
}