using edu.stanford.nlp.tagger.common;
using edu.stanford.nlp.tagger.maxent;

namespace SyntheticsGPTKQL
{
    internal class UserNLPClient : NLPProvider
    {
        Dictionary<String,String> tables;
        public UserNLPClient() 
        {
            tables = new Dictionary<String, String>();
            tables.Add("sybase", "Sybase_Results");
            tables.Add("sockperf", "sockperf_results");
            tables.Add("common", "TestRunDetails,DeploymentMetadata,TestInfraMetadata");
        }
        public override List<String> getEntities(String userPrompt)
        {
            String tableName;
            List<String> tableNames = new List<String>();

            String[] words = userPrompt.Split(' ');
            if (words.Contains("sybase"))
            {
                tableName = null;
                _ = tables.TryGetValue("sybase", out tableName);
                tableNames.Add(tableName);
            }
            if (words.Contains("cassandra"))
            {
                tableName = null;
                _ = tables.TryGetValue("sybase", out tableName);
                tableNames.Add(tableName);
            }
            if (words.Contains("sockperf"))
            {
                tableName = null;
                _ = tables.TryGetValue("sockperf", out tableName);
                tableNames.Add(tableName);
                tableNames.Add("DeploymentMetadata");
                tableNames.Add("TestInfraMetadata");
            }
            if (words.Contains("tests"))
            {
                tableNames.Add("TestRunDetails");

            }
            if (words.Contains("deployments"))
            {
                tableNames.Add("DeploymentMetadata");
            }
            if (words.Contains("infra"))
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
