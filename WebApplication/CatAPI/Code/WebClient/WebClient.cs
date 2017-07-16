using log4net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CatAPI
{
    public class WebClient<T>
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HttpClient client = new HttpClient();

        /// <summary>
        /// get data as an asynchronous operation.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetDataAsync(string url)
        {
            log.Debug($"Start request to {url}");
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                T rsl = DeserializeStream(await response.Content.ReadAsStreamAsync());
                log.Debug("Reading request done");
                return rsl;
            }
            else
            {
                log.Error($"Error when request. Response error: {response.StatusCode} {response.ReasonPhrase}");
            }

            return default(T);
        }

        /// <summary>
        /// Deserializes the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>T.</returns>
        public T DeserializeStream(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(stream);
            T rsl = (T)serializer.Deserialize(reader);
            reader.Close();

            return rsl;
        }
    }
}