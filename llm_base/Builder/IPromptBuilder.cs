using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal interface IPromptBuilder
    {
        void ShowPrompts();
        List<String> buildPrompts(List<String> tableschema, String userPrompt);
        
    }
}
