using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using jdk.nashorn.api.scripting;
using Newtonsoft.Json;


namespace SyntheticsGPTKQL
{
    internal class SQLMetadataManager : MetadataManager
    {
        String kustoClusterURL;
        Dictionary<String, String> sqlMetaData;




        public SQLMetadataManager()
        {
            sqlMetaData = new Dictionary<String, String>();
            String key = "Sybase_Results";
            String value = @"svr_nm nvarchar(max),metric nvarchar(max),MPA_SpidCt int,MPA_TPS float,MPA_LIO_k_PerSec float,MPA_PIO_k_PerSec float,
                            MPA_CPU_k_PerSec float, UTL_PoolNm nvarchar(100),UTL_Pct float, MPW_WtDesc nvarchar(max),MPW_WtTmPct float,
                            MSL_SpinNm nvarchar(max),MSL_k_SpinsPerSec float, MDIO_DevNm nvarchar(max),MDIO_WritesPerESec float,
                            MDIO_ReadsPerESec float, MDIO_Reads float, MDIO_Writes float, MPA_LIO_Ratio float, MPA_Pwrt_k_PerSec float, MPA_BlockedTm float,
                            MPA_BlockedCt int, par_batch_id nvarchar(max),num_parallel int, threads int, db_nm nvarchar(max),monInsertedTime datetime2";
            sqlMetaData.Add(key, value);

            key = "TestExecGroup";
            value = @"TestExecGroupID nvarchar(max),TestExecGroupName nvarchar(max)";
            sqlMetaData.Add(key, value);

            key = "DeploymentMetadata";
            value = "DeploymentID nvarchar(max), DeploymentName nvarchar(max), DeploymentVersion nvarchar(max), DeploymentPrefix nvarchar(max)";
            sqlMetaData.Add(key, value);

            key = "TestRunDetails";
            value = @"TestID nvarchar(max),DeploymentID nvarchar(max),WorkloadID nvarchar(max),TestExecConfigID nvarchar(max),
                            TestName nvarchar(max),ExecutionID nvarchar(max),TestInvocation nvarchar(max),IterationStartTime datetime2,
                            EnvironmentName nvarchar(max),Iteration int, IterationEndTime datetime2";
            sqlMetaData.Add(key, value);

            key = "CassandraTestSummary";
            value = @"TestID nvarchar(max), op_rate float,total_operation_time float,DeploymentID nvarchar(max), WorkloadID nvarchar(max), TestExecConfigID nvarchar(max), 
                      TestType nvarchar(max)";
            sqlMetaData.Add(key, value);

            key = "SockPerf_Results";
            value = @"TestID nvarchar(max), DeploymentID nvarchar(max), WorkloadID nvarchar(max), TestExecConfigID nvarchar(max),ExecutionID nvarchar(max),
                    [avg-latency] float, iteration int";
            sqlMetaData.Add(key, value);


            key = "TestInfraMetadata";
            value = @"WorkloadID nvarchar(max), TestName nvarchar(max),WorkloadName nvarchar(max)";
            sqlMetaData.Add(key, value);

         
        }


        public override List<String> getObjectMetadata(List<String> objectName)
        {

            List<String> tables = new List<String>();

            //var result = JsonConvert.DeserializeObject<Dictionary<String, Object>>(json);
            //System.Console.WriteLine(result);
            foreach (String table in objectName)
            {
                String tableSchema;
                if(sqlMetaData.TryGetValue(table, out tableSchema))
                {
                    tableSchema = "Create table "+table+"( "+tableSchema.ToString() + ")";
                    tables.Add(tableSchema.ToString());

                }
            }
            return tables;
        }
    }
}
