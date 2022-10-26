using BAL;
using Helper;
using JenkinsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JenkinsWebApplication.Controllers
{
    public class pizzaController : Controller
    {
        // GET: pizza
        Helperclass helper = null;
        public pizzaController()
        {
            helper = new Helperclass();
        }

        public ActionResult Index()
        {
            var stulist = helper.List();
            List<Pizza1> modelsList = new List<Pizza1>();
            foreach (var item in stulist)
            {
                modelsList.Add(new Pizza1
                {
                    Order_id = item.Order_id,
                   Food_name = item.Food_name,
                    Cost = item.Cost,
                    
                });
            }

            return View(modelsList);
        }
        public ActionResult Pay()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var data = helper.search(id);
            Pizza1 emp = new Pizza1();
            emp.Order_id = id;
            emp.Food_name = data.Food_name;
            emp.Cost = data.Cost;
            

            return View(emp);

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Pizza bal = new Pizza();
            bal.Order_id = Convert.ToInt32(Request["Order_id"]);
            bal.Food_name = Request["Food_name"].ToString();
            bal.Cost = Convert.ToInt32(Request["Cost"]);
            



            bool ans = helper.AddE(bal);
            if (ans)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var emp = helper.search(id);
            Pizza1 model = new Pizza1();
            model.Order_id= id;
            model.Food_name = emp.Food_name;
            model.Cost = emp.Cost;
           


            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.search(id);
                emp.Order_id = Convert.ToInt32(Request["Order_id"]);
                emp.Food_name = Request["Food_name"].ToString();
                emp.Cost = Convert.ToInt32(Request["Cost"]);
              
                bool ans = helper.Edit(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var emp = helper.search(id);
           Pizza1 model = new Pizza1();
            model.Order_id = id;
            model.Food_name = emp.Food_name;
            model.Cost = emp.Cost;
            


            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.search(id);
                if (dataFound != null)
                {
                    bool ans = helper.remove(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}