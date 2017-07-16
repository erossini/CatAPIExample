using CatAPI.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CatAPI.Code.WebClient
{
    public class ImageWebClient
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// get images as an asynchronous operation.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="resultForPage">The result for page.</param>
        /// <returns>Task&lt;List&lt;Image&gt;&gt;.</returns>
        public async Task<List<Image>> GetImagesAsync(string category, int resultForPage = 10)
        {
            return await GetImagesAsync(new Uri($"http://thecatapi.com/api/images/get?format=xml&results_per_page={resultForPage}&category={category}"));
        }

        /// <summary>
        /// get images as an asynchronous operation.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;List&lt;Image&gt;&gt;.</returns>
        public async Task<List<Image>> GetImagesAsync(Uri url)
        {
            log.Debug("Request for images");
            List<Image> images = null;

            WebClient<Code.Images.response> client = new WebClient<Code.Images.response>();
            Code.Images.response rsl = await client.GetDataAsync(url.ToString());

            if (rsl != null)
            {
                images = new List<Image>();
                foreach (Code.Images.image img in rsl.data.images.image)
                {
                    images.Add(new Models.Image()
                    {
                        Id = img.id.Value,
                        ImageUrl = img.url.Value,
                        Link = img.source_url.Value
                    });
                }
                log.Debug("Images converted");
            }
            else
            {
                log.Error("No result for images request");
            }

            return images;
        }
    }
}