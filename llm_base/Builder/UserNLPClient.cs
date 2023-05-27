using edu.stanford.nlp.tagger.common;
using edu.stanford.nlp.tagger.maxent;

namespace SyntheticsGPTKQL
{
    internal class UserNLPClient : NLPProvider
    {

        public UserNLPClient() 
        {
           
        }
        public override List<String> getEntities(String userPrompt)
        {
            String tableName;
            List<String> tableNames = new List<String>();

            String[] words = userPrompt.Split(' ');
            if (words.Contains("Sybase_Results"))
            {
                //tableName = null;
               
                tableNames.Add("Sybase_Results");
            }
            //if (words.Contains("cassandra"))
            //{
                //tableName = null;
       
                //tableNames.Add(tableName);
            //}
            if (words.Contains("SockPerf_Results"))
            {
                //tableName = null;
                
                tableNames.Add("SockPerf_Results");
                tableNames.Add("DeploymentMetadata");
                tableNames.Add("TestInfraMetadata");
            }
            if (words.Contains("TestRunDetails"))
            {
                tableNames.Add("TestRunDetails");

            }
            if (words.Contains("deployments"))
            {
                tableNames.Add("DeploymentMetadata");
            }
            if (words.Contains("TestInfraMetadata"))
            {
                tableNames.Add("TestInfraMetadata");
                
            }

            

            return tableNames;
        }

        public override List<string> getIntents(string userPrompt)
        {
            throw new NotImplementedException();
        }
    }
}
