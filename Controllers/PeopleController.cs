using CrudMVCRazorFetch.Models;
using CrudMVCRazorFetch.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCRazorFetch.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<PeopleViewModel> listPeopleViewModels = new List<PeopleViewModel>();
            
            using (CrudMVCRazorFetchEntities db = new CrudMVCRazorFetchEntities())
            {
                listPeopleViewModels = (from d in db.people
                                       orderby d.age descending
                                       select new PeopleViewModel { 
                                            Id= d.id,
                                            Name= d.name,
                                            Age= d.age
                                       }).ToList<PeopleViewModel>();

            }
            return View(listPeopleViewModels);
        }
    }
}