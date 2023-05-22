using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SyntheticsGPTKQL;

namespace WebSyntheticGPTKQL.Model.View
{
    public class QueryBuilderView : PageModel
    {
        //private readonly PromptController promptController;

        [BindProperty]
        public string UserQuery { get; set; }

        /*public QueryBuilderView(PromptController promptController) {
            this.promptController = promptController;
        }*/

        public void OnPost()
        {
            string query = UserQuery;
            /*PromptController promptController = new PromptController();
            List<string> prompts = promptController.buildPrompts(UserQuery);
            LLMClient gptClient = LLMApater.getLLMInstance();
            gptClient.setProperties();
            gptClient.invokeLLMCommandAsync(prompts, "");*/
        }
    }
}
