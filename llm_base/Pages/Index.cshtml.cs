using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SyntheticsGPTKQL;
using System.Text.Json;
using WebSyntheticGPTKQL.Builder;

namespace WebSyntheticGPTKQL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string UserQuery { get; set; }

        public string Prompts { get; set; }

        public string KQLQuery { get; set; }

        public JsonDocument DataSet { get; set; }

        public string TableName { get; set; }
        public string Query { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string WelcomeMessage { get; set; }

        public void OnGet()
        {
            WelcomeMessage = "Synthetics LLM Query Builder";
            string jsonData = @"
                {
                    ""data"": [
                        {
                            ""TestID"": 1,
                            ""DeploymentID"": 101,
                            ""WorkloadID"": 201,
                            ""TestExecConfigID"": 301,
                            ""ExecutionID"": 401,
                            ""TestName"": ""Test 1"",
                            ""TestInvocation"": ""Invocation 1"",
                            ""IterationStartTime"": ""2023-05-18T10:00:00Z"",
                            ""IterationEndTime"": ""2023-05-18T10:05:00Z"",
                            ""EnvironmentName"": ""Environment 1"",
                            ""ErrorReporte"": false,
                            ""ErrorDescription"": """",
                            ""Iteration"": 1,
                            ""StartTime"": ""2023-05-18T10:00:00Z"",
                            ""EndTime"": ""2023-05-18T10:05:00Z"",
                            ""ParseTimeUTC"": ""2023-05-18T10:05:00Z"",
                            ""PersistenceId"": ""ID001"",
                            ""InsertDateTimeUTC"": ""2023-05-18T10:05:00Z"",
                            ""InsertDateUTC"": ""2023-05-18"",
                            ""InsertTimeUTC"": ""10:05:00Z""
                        },
                        {
                            ""TestID"": 2,
                            ""DeploymentID"": 102,
                            ""WorkloadID"": 202,
                            ""TestExecConfigID"": 302,
                            ""ExecutionID"": 402,
                            ""TestName"": ""Test 2"",
                            ""TestInvocation"": ""Invocation 2"",
                            ""IterationStartTime"": ""2023-05-18T11:00:00Z"",
                            ""IterationEndTime"": ""2023-05-18T11:05:00Z"",
                            ""EnvironmentName"": ""Environment 2"",
                            ""ErrorReporte"": true,
                            ""ErrorDescription"": ""Error occurred"",
                            ""Iteration"": 1,
                            ""StartTime"": ""2023-05-18T11:00:00Z"",
                            ""EndTime"": ""2023-05-18T11:05:00Z"",
                            ""ParseTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""PersistenceId"": ""ID002"",
                            ""InsertDateTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""InsertDateUTC"": ""2023-05-18"",
                            ""InsertTimeUTC"": ""11:05:00Z""
                        },
                        {
                            ""TestID"": 3,
                            ""DeploymentID"": 110,
                            ""WorkloadID"": 202,
                            ""TestExecConfigID"": 302,
                            ""ExecutionID"": 402,
                            ""TestName"": ""Test 2"",
                            ""TestInvocation"": ""Invocation 2"",
                            ""IterationStartTime"": ""2023-05-18T11:00:00Z"",
                            ""IterationEndTime"": ""2023-05-18T11:05:00Z"",
                            ""EnvironmentName"": ""Environment 2"",
                            ""ErrorReporte"": true,
                            ""ErrorDescription"": ""Error occurred"",
                            ""Iteration"": 1,
                            ""StartTime"": ""2023-05-18T11:00:00Z"",
                            ""EndTime"": ""2023-05-18T11:05:00Z"",
                            ""ParseTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""PersistenceId"": ""ID002"",
                            ""InsertDateTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""InsertDateUTC"": ""2023-05-18"",
                            ""InsertTimeUTC"": ""11:05:00Z""
                        },
                        {
                            ""TestID"": 4,
                            ""DeploymentID"": 202,
                            ""WorkloadID"": 202,
                            ""TestExecConfigID"": 302,
                            ""ExecutionID"": 402,
                            ""TestName"": ""Test 2"",
                            ""TestInvocation"": ""Invocation 2"",
                            ""IterationStartTime"": ""2023-05-18T11:00:00Z"",
                            ""IterationEndTime"": ""2023-05-18T11:05:00Z"",
                            ""EnvironmentName"": ""Environment 2"",
                            ""ErrorReporte"": true,
                            ""ErrorDescription"": ""Error occurred"",
                            ""Iteration"": 1,
                            ""StartTime"": ""2023-05-18T11:00:00Z"",
                            ""EndTime"": ""2023-05-18T11:05:00Z"",
                            ""ParseTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""PersistenceId"": ""ID002"",
                            ""InsertDateTimeUTC"": ""2023-05-18T11:05:00Z"",
                            ""InsertDateUTC"": ""2023-05-18"",
                            ""InsertTimeUTC"": ""11:05:00Z""
                        }]}";



            DataSet = JsonDocument.Parse(jsonData);
        }

        public async Task OnPost()
        {
            WelcomeMessage = "Synthetics LLM Query Builder";
            if (ModelState.IsValid)
            {
            
                UserQuery = Request.Form["UserQuery"];
                TableName = Request.Form["TableName"];
                String userPrompt = UserQuery + " from " + Request.Form["TableName"];
                PromptController promptController = new PromptController();
                promptController.setPersona("user");
                promptController.initializePromptController();
                List<string> prompts = promptController.buildPrompts(userPrompt);
                // Set the value in the Prompts property
                Prompts = string.Join(Environment.NewLine, prompts);

                LLMClient gptClient = LLMApater.getLLMInstance();
                gptClient.setProperties();
                 KQLQuery = await gptClient.invokeLLMCommandAsync(prompts, "");
                
                Query = "Select " + KQLQuery.Replace("\n", " ");

                QueryExecutor executor = QueryExecutionAdapter.getQueryExecutor();
                String jsonData = executor.executeQuery("sql", Query).Result.ToString();
                if (jsonData.Length == 0) 
                {
                    jsonData = @"{""data"": [{
                            ""Results"": ""No records in DB""}]}";
                }
               
                DataSet = JsonDocument.Parse(jsonData);
                
            }

                
            

        }

        
    }
}