using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4chanApiWrapper.Models
{
    public partial class Post
    {
        public long No { get; set; }
        public string Now { get; set; }
        public string Name { get; set; }
        public string Sub { get; set; }
        public string Com { get; set; }
        public string Filename { get; set; }
        public string Ext { get; set; }
        public long? W { get; set; }
        public long? H { get; set; }
        public long? TnW { get; set; }
        public long? TnH { get; set; }
        public long? Tim { get; set; }
        public long Time { get; set; }
        public string Md5 { get; set; }
        public long? Fsize { get; set; }
        public long Resto { get; set; }
        public long? Bumplimit { get; set; }
        public long? Imagelimit { get; set; }
        public string SemanticUrl { get; set; }
        public long? Replies { get; set; }
        public long? Images { get; set; }
        public long? UniqueIps { get; set; }
    }
}
