using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SyntheticsGPTKQL
{
    internal class PromptController
    {

        NLPProvider nlpClient;
        MetadataManager kqlMetadataManager;

        List<String> tableSchema;
        List<String> tableNames;
        List<String> prompts;

        PromptBuilder promptBuilder;

        String persona;

        public void setPersona(String persona)
        { this.persona = persona; }
        public void initializePromptController()
        {
            nlpClient = NLPAdapter.getNLPClient(this.persona);
            kqlMetadataManager = DomainAdapter.getMetadataManager(); ;
            promptBuilder = PromptAdapter.getPromptBuilder();
        }

        public List<String> buildPrompts(String userPrompt)
        {
    
            tableNames = nlpClient.getEntities(userPrompt);
            tableSchema = kqlMetadataManager.getObjectMetadata(tableNames);
            prompts = promptBuilder.buildPrompts(tableSchema,userPrompt);


            return prompts.ToList();

        }
    }
}
