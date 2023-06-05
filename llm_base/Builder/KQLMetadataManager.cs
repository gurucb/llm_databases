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
    internal class KQLMetadataManager : MetadataManager
    {
        String kustoClusterURL;
        //TODO: Connect to kusto Cluster
        String json = @"{
      
        'TestExecConfiguration':'TestExecConfigID,TestName,TestExecConfigName,TestInvocationConfigParameters,LastUpdatedAt',
        'Executionlog':'TestIDExecutionID,ResourceID,SourceComponent,SubComponent,Operation,LogInfo,Parameters,StartTimeUTC,EndTimeUTC,Account,AdditionalInfo,Iteration,VmName,TestName,ExecutionLogID,InsertDateTimeUTC,InsertedDateUTC,InsertedTimeUTC',
        'Resources':'ProvisionIDazEnvironment,location,name,computerName,platformFaultDomain,platformUpdateDomain,osType,subscriptionId,tags,vmId,vmScaleSetName,vmSize,zone,publisher,resourceGroupName,resourceId,sku,tagsList,placementGroupId,imageReferenceId,ResourcePersistID,ResourcePersistenceDateTimeUTC',
        'ResourceDisk': 'ProvisionIDVMId,DiskType,caching,createOption,diskSizeGB,name,writeAcceleratorEnabled,imageURI,managedDiskId,storageAccountType,VHDUri,ResourcePersistID',
        'ResourceNetwork': 'ProvisionIDVMId,MACAddress,IPv4Address,IPv4Subnet,IPv6,ResourcePersistID',
        'TcpPingResults': 'TestIDDeploymentID,WorkloadID,TestExecConfigID,ExecutionID,IterationStartTime,IterationEndTime,EnvironmentName,Iteration,SequenceId,SeqStartDateTime,SeqEndDateTime,HostIp,SignalText,LatencyValue,TcppingPersistanceId,ErrorDescription',
        'CassandraTestSummary':'op_rate,total_operation_time,DeploymentID, WorkloadID, TestExecConfigID, TestType',
        'TestRunDetails': 'TestID,DeploymentID,WorkloadID,TestExecConfigID,TestName,ExecutionID,TestInvocation,IterationStartTime,EnvironmentName,Iteration,IterationEndTime',
        'TestExecGroup': 'TestExecGroupID,TestExecGroupName',
        'Sybase_Results': 'svr_nm,metric,MPA_SpidCt,MPA_TPS,MPA_LIO_k_PerSec,MPA_PIO_k_PerSec,MPA_CPU_k_PerSec,UTL_PoolNm,UTL_Pct,MPW_WtDesc,MPW_WtTmPct,MSL_SpinNm,MSL_k_SpinsPerSec,MDIO_DevNm,MDIO_WritesPerESec,MDIO_ReadsPerESec,MDIO_Reads,MDIO_Writes,MPA_LIO_Ratio,MPA_Pwrt_k_PerSec,MPA_BlockedTm,MPA_BlockedCt,par_batch_id,num_parallel,threads,db_nm,monInsertedTime',
        'SockPerf_Results': 'TestID ,DeploymentID ,WorkloadID ,TestExecConfigID ,ExecutionID ,[avg-latency]',
        'DeploymentMetadata':'DeploymentID, DeploymentName, DeploymentVersion, DeploymentPrefix',
        'TestInfraMetadata': 'WorkloadID, TestName,WorkloadName'}";
        public override List<String> getObjectMetadata(List<String> objectName)
        {

            List<String> tables = new List<String>();

            var result = JsonConvert.DeserializeObject<Dictionary<String, Object>>(json);
            System.Console.WriteLine(result);
            foreach (String table in objectName)
            {
                Object tableSchema;
                if(result.TryGetValue(table, out tableSchema))
                {
                    tableSchema = "Table "+table+" with columns "+tableSchema.ToString();
                    tables.Add(tableSchema.ToString());

                }
            }
            return tables;
        }
    }
}
