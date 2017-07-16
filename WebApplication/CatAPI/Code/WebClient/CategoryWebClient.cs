using CatAPI.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CatAPI.Code.WebClient
{
    public class CategoryWebClient
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// get categories as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;List&lt;Category&gt;&gt;.</returns>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await GetCategoriesAsync(new Uri("http://thecatapi.com/api/categories/list"));
        }

        /// <summary>
        /// get categories as an asynchronous operation.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;List&lt;Category&gt;&gt;.</returns>
        public async Task<List<Category>> GetCategoriesAsync(Uri url)
        {
            log.Debug("Request for categories");
            List<Category> categories = null;

            WebClient<Code.Categories.response> client = new WebClient<Code.Categories.response>();
            Code.Categories.response rsl = await client.GetDataAsync(url.ToString());

            if (rsl != null)
            {
                categories = new List<Category>();
                foreach (Code.Categories.category cat in rsl.data.categories.category)
                {
                    categories.Add(new Models.Category() { Id = Convert.ToInt32(cat.id.Value.ToString()), Name = cat.name.Value.ToString() });
                }
                log.Debug("Categories converted");
            }
            else
            {
                log.Error("No result for categories request");
            }

            return categories;
        }
    }
}