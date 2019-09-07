using System.Collections.Generic;
using FileHelpers;

namespace Lybecker.SolrNetClient
{
    public class FileParser<T>
    {
        public IEnumerable<T> Parse(string filePath)
        {
            var engine = new FileHelperEngine<T>();

            return engine.ReadFile(filePath); 
        }
    }
}