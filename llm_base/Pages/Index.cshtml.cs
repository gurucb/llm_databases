using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SyntheticsGPTKQL;

namespace WebSyntheticGPTKQL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string UserQuery { get; set; }

        public string Prompts { get; set; }

        public string KQLQuery { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string WelcomeMessage { get; set; }

        public void OnGet()
        {
            //WelcomeMessage = "WelCome";
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
            
                UserQuery = Request.Form["UserQuery"];
                String userPrompt = UserQuery + " " + Request.Form["dbs"];
                PromptController promptController = new PromptController();
                promptController.setPersona("user");
                promptController.initializePromptController();
                List<string> prompts = promptController.buildPrompts(userPrompt);
                // Set the value in the Prompts property
                Prompts = string.Join(Environment.NewLine, prompts);

                LLMClient gptClient = LLMApater.getLLMInstance();
                gptClient.setProperties();
                KQLQuery = await gptClient.invokeLLMCommandAsync(prompts, "");
            }
        }

        
    }
}