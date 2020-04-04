using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevAssignment.Models
{
    public class BarefootProximityModel
    {
        #region Properties
        public ModelStateDictionary ModelState { get; set; } = new ModelStateDictionary();

        [Display(Name = "Create List of Strings to Search (comma delimited)")]
        [DataType(DataType.MultilineText)] 
        [Required(ErrorMessage = "Please enter a comma delimited list of search strings.")]
        public string SearchList { get; set; } = "Lovelace, Hamilton, Hopper, Gates, Torvalds, Gosling, Eich, Crockford, Dahl"; 

        public List<string> Items { get; set; } = new List<string>();

        [Display(Name = "Enter Search Criteria")]
        public string SearchCriteria { get; set; } = string.Empty;

        public List<string> SearchResults { get; set; } = new List<string>();
        #endregion

        #region Constructors
        /// <summary>
        /// Default costructor. Assumes that properties will be set externally.
        /// </summary>
        public BarefootProximityModel()
        {
            // Set default model properties.
        }
        #endregion
    }
}