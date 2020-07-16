using _4chanApiWrapper;
using _4chanApiWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace TesterGUI
{
    public partial class MainGUI : Form
    {
        static FourChanApi api = new FourChanApi();
        List<string> boardsOfInterest = new List<string>();
        public void DownloadImages()
        {
            boardsOfInterest = textBox1.Text.Split(';').ToList();

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
                                            string path = board + "/" + post.Tim + post.Ext;
                                            client.DownloadFile(new Uri(urlForImage), path);
                                            pictureBox1.Load(urlForImage);
                                            pictureBox1.Update();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("couldnt download file!");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public MainGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadImages();
        }
    }
}
