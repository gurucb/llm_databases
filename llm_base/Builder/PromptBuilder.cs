using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal abstract class PromptBuilder : IPromptBuilder
    {
        public abstract List<String> buildPrompts(List<string> tableschema, String userPrompt);
        public abstract void ShowPrompts();
    }
}
