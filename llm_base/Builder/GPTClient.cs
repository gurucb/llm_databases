using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace SyntheticsGPTKQL
{
    internal class GPTClient:LLMClient
    {

        //public async Task<Completions> GetCompletionsAsync()
        public async Task<string> GetCompletionsAsync(List<String> prompts)
        {
            String finalPrompt = "\n";
            foreach (var prompt in prompts)
            {
                finalPrompt += "\n" + prompt + "\n";
            }
           

            Response<Completions> completionsResponse = await oaiClient.GetCompletionsAsync
                (
                    deploymentOrModelName: "syntheticsGPTKQL",
                    new CompletionsOptions()
                    {
                        
                        Prompts = { finalPrompt },
                        Temperature = Temperature,
                        MaxTokens = MaxTokens,
                        StopSequences = { "#", ";" },
                        NucleusSamplingFactor = NucleusSamplingFactor,
                        FrequencyPenalty = FrequencyPenalty,
                        PresencePenalty = PresencePenalty,
                        //GenerationSampleCount = 1,
                        //Echo = false,
                        //ChoicesPerPrompt=1,
            
                    }); 
            Completions completions = completionsResponse.Value;
            String responseKQL = completions.Choices[0].Text;
            //int startPosition = responseKQL.IndexOf("Output");
            //int endPosition = responseKQL.Length;
            //String commandKQL = responseKQL.Substring(startPosition, endPosition - startPosition);
            //System.Console.WriteLine("\n");
            //System.Console.WriteLine(commandKQL);
            return responseKQL;
        }

        public async override Task<string> invokeLLMCommandAsync(List<String> prompts, string model)
        {
             string kqlQuery = await this.GetCompletionsAsync(prompts);
             return kqlQuery;
        }
    }
}
