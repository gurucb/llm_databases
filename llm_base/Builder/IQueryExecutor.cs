namespace WebSyntheticGPTKQL.Builder
{
    public interface IQueryExecutor
    {
        public Task<String> executeQuery(String queryType, String query);
    }
}
