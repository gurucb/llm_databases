using com.sun.corba.se.impl.corba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class SyntheticsGPTPromptBuilder : PromptBuilder
    {
        public override List<String> buildPrompts(List<string> tableschema, String userPrompt)
        {
            List<String> prompts = new List<String>();
            System.Console.WriteLine("**************************");

            prompts.Add("Given an input generate a syntactically correct SQL Query Language for Microsoft SQL Server.");
            prompts.Add("### SQL Tables with their properties:\n");
            foreach(String table in tableschema)
            {
                prompts.Add(table);
            }
            prompts.Add("\n### "+userPrompt+"\n SELECT ");

            return prompts;
        }

        public override void ShowPrompts()
        {
            throw new NotImplementedException();
        }
    }
}
