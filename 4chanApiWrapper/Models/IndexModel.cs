using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourChanAPIWrapper.Models
{
    public partial class IndexModel
    {

        public Thread[] Threads { get; set; }
    }

    public partial class ThreadModel
    {
        public bool isEmpty = false;
        public Post[] Posts { get; set; }
    }
}
