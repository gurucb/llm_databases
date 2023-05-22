using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal abstract class MetadataManager : IMetadataManager
    {
      public abstract List<String> getObjectMetadata(List<String> objectName);
    }
}
