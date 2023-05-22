namespace WebSyntheticGPTKQL.Builder
{
    public abstract class QueryExecutor : IQueryExecutor
    {
        public abstract void executeQuery(string queryType, string query);
    }
}
