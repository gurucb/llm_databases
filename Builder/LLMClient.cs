using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;



namespace SyntheticsGPTKQL
{
    internal abstract class LLMClient:ILLMClient
    {
        protected float Temperature;
        protected int MinTokens;
        protected int MaxTokens;
        protected List<String> StopSequences;
        protected float NucleusSamplingFactor;
        protected float FrequencyPenalty;
        protected float PresencePenalty;
        protected OpenAIClient oaiClient;
        Uri uri;
        AzureKeyCredential azureKeyCredential;
        protected Response<Completions> completionsResponse;

        public void setProperties()
        {
            this.Temperature = 0.0f;
            this.MinTokens = 100;
            this.MaxTokens = 500;
            this.NucleusSamplingFactor = 0.0f;
            this.FrequencyPenalty = 0.74f;
            this.PresencePenalty = 0.0f;
            this.FrequencyPenalty = 0.0f;
            this.uri = new Uri("https://syntheticsoai.openai.azure.com/");
            this.azureKeyCredential = new AzureKeyCredential("d12cf2ed7e14418ab2fb6783b3414e1a");
            this.oaiClient = new OpenAIClient(uri, azureKeyCredential);
        }

        public abstract Task<string> invokeLLMCommandAsync(List<String> prompts, string model);
    }
}
