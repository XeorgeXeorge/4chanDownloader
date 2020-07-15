using _4chanApiWrapper;
using _4chanApiWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static FourChanApi api = new FourChanApi();
        static string[] boardsOfInterest = new string[] { "h" };

        public static void DownloadImages()
        {
            int pageIndex = 0;
            int maxPages = 0;

            int threadIndex = 0;
            int postIndex = 0;

            int maxThreads = 0;
            int maxPosts = 0;

            foreach (string board in boardsOfInterest)
            {

                pageIndex = 0;
                System.IO.Directory.CreateDirectory(board);

                var boardCatalog = api.GetCatalog(board);

                // go over every thread
                maxPages = boardCatalog.Count();
                boardCatalog.Reverse(); // reverse the pages to the oldest threads are getting downloaded first => before they get pruned or delélted
                foreach (var page in boardCatalog)
                {
                    pageIndex++;
                    maxThreads = page.threads.Count();
                    threadIndex = 0;

                    foreach (var thread in page.threads)
                    {
                        threadIndex++;
                        postIndex = 0;
                        // get every thread
                        ThreadModel th = api.GetThread(board, thread.no.ToString());
                        if (th.isEmpty == false)
                        {
                            maxPosts = th.Posts.Count();

                            foreach (var post in th.Posts)
                            {
                                postIndex++;

                                if (post.Ext != null)
                                {
                                    // image download => https://i.4cdn.org/[board]/[4chan image ID].[file extension]
                                    string urlForImage = "https://i.4cdn.org/" + board + "/" + post.Tim + post.Ext;
                                    Console.WriteLine("[" + board + "]" + " Page: " + pageIndex + " / " + maxPages);
                                    Console.WriteLine("[" + board + "]" + " Thread: " + threadIndex + " / " + maxThreads);
                                    Console.WriteLine("[" + board + "]" + " Post: " + postIndex + " / " + maxPosts);
                                    Console.WriteLine(urlForImage);

                                    try
                                    {
                                        using (WebClient client = new WebClient())
                                        {
                                            client.DownloadFile(new Uri(urlForImage), board + "/" + post.Tim + post.Ext);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("couldnt download file!");
                                    }
                                    Console.Clear();

                                }
                            }
                        }
                    }
                }
            }
        }


        static void Main(string[] args)
        {

            DownloadImages();
            

            Console.ReadLine();
        }
    }
}
