using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpp.RssReader
{
    class RssItem
    {
        internal string Title { get; set; }
        internal string Category { get; set; }
        internal string Description { get; set; }
        internal string PubDate { get; set; }
        internal string Link { get; set; }
        
        public RssItem (string title, string link, string description, string category, string pubdate)
        {
            Title = title;
            Category = category;
            Description = description;
            PubDate = pubdate;
            Link = link;
        }
    }
}
