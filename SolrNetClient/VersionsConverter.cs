using System.Collections.Generic;
using FileHelpers;

namespace Lybecker.SolrNetClient
{
    class VersionsConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            var versions = new List<string>();

            foreach (var version in from.Split(','))
            {
                versions.Add(version.Trim());
            }

            return versions;
        }
    }
}