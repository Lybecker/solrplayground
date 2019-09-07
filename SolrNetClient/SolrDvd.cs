using System.Collections.Generic;
using SolrNet.Attributes;

namespace Lybecker.SolrNetClient
{
    public class SolrDvd
    {
        [SolrField("title")]
        public string Title { get; set; }
        [SolrField("studio")]
        public string Studio { get; set; }
        [SolrField("versions")]
        public IEnumerable<string> Versions { get; set; }
        [SolrField("rating")]
        public string Rating { get; set; }
        [SolrField("year")]
        public string Year { get; set; }
        [SolrField("genre")]
        public string Genre { get; set; }
        [SolrUniqueKey("id")]
        public int Id { get; set; }
    }
}