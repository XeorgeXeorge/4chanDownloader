using FourChanAPIWrapper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace FourChanAPIWrapper
{
    public class FourChanApi
    {
        /// <summary>
        /// Gets the catalog of the specified board, returns a List with all pages currently online
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public List<CatalogModel> GetCatalog(string board)
        {
            string url = "https://a.4cdn.org/" + board + "/catalog.json";
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);

                string trimmedJson = json.Substring(1, json.Length - 2);

                List<CatalogModel> catalog = JsonConvert.DeserializeObject<List<CatalogModel>>(json);
                return catalog;
            }
        }

        /// <summary>
        /// Gets a specific thread on a specific board
        /// </summary>
        /// <param name="board">ex: b</param>
        /// <param name="postnumber">ex: 830908754</param>
        /// <returns></returns>
        public ThreadModel GetThread(string board, string postnumber)
        {
            string url = "https://a.4cdn.org/" + board + "/thread/" + postnumber + ".json";
            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString(url);

                    string trimmedJson = json.Substring(1, json.Length - 2);

                    ThreadModel thread = JsonConvert.DeserializeObject<ThreadModel>(json);
                    thread.isEmpty = false;
                    return thread;
                }catch(Exception ex)
                {
                    Console.WriteLine("url not found, the thread probably got pruned");
                }
                return new ThreadModel();
            }
        }


        /// <summary>
        /// Gets a specific page from a specific board
        /// </summary>
        /// <param name="board">ex: b</param>
        /// <param name="number">ex: 1 (1-15)</param>
        /// <returns></returns>
        public IndexModel GetPage(string board, int number)
        {
            string url = "https://a.4cdn.org/" + board + "/" + number + ".json";
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);

                string trimmedJson = json.Substring(1, json.Length - 2);

                IndexModel indexPage = JsonConvert.DeserializeObject<IndexModel>(json);
                return indexPage;
            }
        }


    }
}
