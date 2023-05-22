using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class PromptAdapter
    {
        public static PromptBuilder getPromptBuilder()
        {
            PromptBuilder promptBuilder = new SyntheticsGPTPromptBuilder();
            return promptBuilder;
        }
    }
}
