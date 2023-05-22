namespace WebSyntheticGPTKQL.Builder
{
    public abstract class QueryExecutor : IQueryExecutor
    {
        public abstract Task<String> executeQuery(string queryType, string query);
    }
}
