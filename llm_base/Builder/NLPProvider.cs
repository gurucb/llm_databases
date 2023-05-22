using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal abstract class NLPProvider : INLPProvider
    {
        String[] stopWords;
        char wordBreaker;
        public abstract List<string> getEntities(string userPrompt);
        public abstract List<string> getIntents(string userPrompt);
    }
}
