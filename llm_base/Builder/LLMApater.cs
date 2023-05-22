using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class LLMApater
    {
        public static LLMClient getLLMInstance()
        {
            LLMClient llmClient = new GPTClient();
            return llmClient;
        }
    }
}
