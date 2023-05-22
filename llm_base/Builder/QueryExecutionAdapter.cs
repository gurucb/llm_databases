using SyntheticsGPTKQL;

namespace WebSyntheticGPTKQL.Builder
{
    public class QueryExecutionAdapter
    {
        public static QueryExecutor getQueryExecutor()
        {
            QueryExecutor executor = new SQLExecutor();
            
            return executor;
        }
    }
}
