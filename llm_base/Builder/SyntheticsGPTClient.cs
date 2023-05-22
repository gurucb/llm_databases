using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class SyntheticsGPTClient
    {
        NLPProvider nlpClient;
        MetadataManager kqlMetadataManager;
        LLMClient gptClient;

        List<String> prompts;
        String model = "";

        public void getKQLOutput()
        {
            
            PromptController promptController = new PromptController();
            prompts = promptController.buildPrompts("From tables TestRunDetails and Resources generate KQL Query to retrieve only last 10 resource names that ran 'Sybase' tests based on datetime");
            gptClient = LLMApater.getLLMInstance();
            gptClient.setProperties();
            gptClient.invokeLLMCommandAsync(prompts,model);
        }
    }
}
