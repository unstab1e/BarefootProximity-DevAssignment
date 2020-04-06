using DevAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAssignment.Controllers
{
    public class BarefootProximityController : Controller
    {
        // GET: BarefootProximity
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Parses the given BarefootProximityModel's comma delimited SearchList into individual Items.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BarefootProximityModel PopulateItemsList(BarefootProximityModel model)
        {
            // Model's SearchList contains a value?
            if (null != model.SearchList && !string.IsNullOrEmpty(model.SearchList))
            {
                // Yes - Create string array from SearchList.
                string[] items = model.SearchList.Split(',');
                // Cycle through items in array to create Items.
                for (int i = 0; i < items.Length; i++)
                {
                    model.Items.Add(items[i].Trim());
                }
            }

            // Return given model.
            return model;
        }


        /// <summary>
        /// Procedure called from index page via a form submit.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ProcessSearchList(BarefootProximityModel model)
        {
            // Given model state valid?
            if (ModelState.IsValid)
            {
                // Yes - Populate Items List.
                model = PopulateItemsList(model);

                Session["BarefootProximityItems"] = model.Items;
                // Redirect to Search page.
                return View("/Views/BarefootProximity/Search.cshtml", model);
            }
            else
            {
                // No - Remain on index page.
                return View("/Views/Home/Index.cshtml", model);
            }
       }


        /// <summary>
        ///  Procedure called to execute search agains Items in model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BarefootProximityModel ExecuteSearch (BarefootProximityModel model)
        {
            // Does the model Search Criteria contain a value?
            if (!string.IsNullOrEmpty(model.SearchCriteria))
            {
                // Yes - Retrieve the Items that contain the Search Criteria.
                //  Items will be returned regardless of case
                model.SearchResults = model.Items.Where(i => i.ToLower().Contains(model.SearchCriteria.ToLower())).ToList();
            }

            return model;
        }
        /// <summary>
        /// Procedure call from Search page to execute search.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
       public ActionResult Search(BarefootProximityModel model)
        {
            // Re-initialize Search Results.
            model.SearchResults = new List<string>();

            // Does the Barefoot Proximity Items Session variable exist?
            if (null != Session["BarefootProximityItems"])
            {
                // Yes - Retrieve the stored Barefoot Proximity Items from the Session variable.
                model.Items = (List<string>)Session["BarefootProximityItems"];

            }

            model = ExecuteSearch(model);

            // Open the Search with the updated model.
            return View("/Views/BarefootProximity/Search.cshtml", model);
        }
    }
}