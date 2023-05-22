using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntheticsGPTKQL
{
    internal class NLPAdapter
    {
        public static NLPProvider getNLPClient(String persona)
        {
            NLPProvider nlpClient;
            if (persona.Equals("user"))
            {
                nlpClient = new UserNLPClient();
            }
            else
            {
                nlpClient = new StanfordNLPClient();
            }
            
            return nlpClient;
        }
    }
}
