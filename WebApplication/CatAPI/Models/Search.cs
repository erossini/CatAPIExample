using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatAPI.Models
{
    public class Search
    {
        /// <summary>
        /// Gets or sets the categories list.
        /// </summary>
        /// <value>The categories list.</value>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public List<Image> Images { get;  set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public string CategoryName { get; set; } = "";
    }
}