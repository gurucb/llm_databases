using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class DomainAdapter
    {
        public static MetadataManager getMetadataManager()
        {
            MetadataManager  metadataManager = new KQLMetadataManager();
            return metadataManager;
        }
    }
}
