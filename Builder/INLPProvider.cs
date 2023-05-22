using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal interface INLPProvider
    {
        List<String> getIntents(String userPrompt);

        List<String> getEntities(String userPrompt);
    }
}
