using System;
using java.io;
using java.util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger;
using edu.stanford.nlp.tagger.common;
using edu.stanford.nlp.tagger.maxent;
using com.sun.xml.@internal.ws.client;

namespace SyntheticsGPTKQL
{
    internal class StanfordNLPClient : NLPProvider
    {
        Tagger tagger = new MaxentTagger();
        String[] tables = { "ProvisionDetails", "TestRunDetails", "TestExecGroup", "TestExecConfiguration", "Resources", "ResourceDisk", "ResourceNetwork", "TcpPingResults", "CassandraTestMeta" };
       /// <summary>
       /// TODO: Use GPT to extract 
       /// </summary>
       /// <param name="userPrompt"></param>
       /// <returns></returns>
        public override List<String> getEntities(String userPrompt)
        {
            List<String> tableNames = new List<string>();
            var modelsDirectory = @"C:\\source\\WebSyntheticGPTKQL\\stanford-tagger-4.2.0\\stanford-postagger-full-2020-11-17";
            var model = modelsDirectory + @"\\models\\english-bidirectional-distsim.tagger";
            var tagger = new MaxentTagger(model);
            
            // Text for tagging
            String [] wrods = userPrompt.Split(' ');
            foreach (var w in wrods)
            {
                String noun = tagger.tagString(w);
                if (noun != null && noun.Contains("NN")) 
                {

                    String tableName = noun.Split('_')[0];
                    var result = Array.Find(tables, element => element == tableName);
                    if (result != null) { 
                    tableNames.Add(noun.Split('_')[0]);
                    }
                }
            }
            return tableNames;
        }

        public override List<string> getIntents(string userPrompt)
        {
            throw new NotImplementedException();
        }
    }
}
