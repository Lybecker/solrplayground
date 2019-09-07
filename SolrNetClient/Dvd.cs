using System.Collections.Generic;
using FileHelpers;

namespace Lybecker.SolrNetClient
{
    [IgnoreFirst]
    [DelimitedRecord(";")]
    public class Dvd
    {
        [FieldQuoted]
        public string Title;
        public string Studio;
        [FieldConverter(typeof(VersionsConverter))] 
        public List<string> Versions;
        public string Rating;
        public string Year;
        public string Genre;
        public int Id;

        public override string ToString()
        {
            return string.Format("Title: {0} Rating: {1} Genre: {2} Studio: {3} Year: {4} Version: {4}", Title, Rating, Genre, Studio, Year, Versions);
        }
    }
}
