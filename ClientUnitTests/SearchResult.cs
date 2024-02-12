using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUnitTests
{
    public class SearchResult
    {
        public string FeedUrl { get; set; }
        public string CollectionName { get; set; }

        public string[] genres { get; set; }

        public string artistName { get; set; }

    }
}
