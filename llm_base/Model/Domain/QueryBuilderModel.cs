namespace WebSyntheticGPTKQL.Model.Domain
{
    public class QueryBuilderModel
    {
        public string UserQuery { get; set; }

        public List<string> Prompts { get; set; }

        public string KQLQuery { get; set; }
    }
}
