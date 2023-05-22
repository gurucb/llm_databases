using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal interface ILLMClient
    {
        Task<string> invokeLLMCommandAsync(List<String> prompts, String model);
    }
}
