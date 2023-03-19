using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9._1
{
    class UserTextConvert
    {
        public string[] UserTextSplit(string userText)
        {
            string[] userTextSplited = userText.Split(' ');
            return userTextSplited;
        }
        public string UserTextReverse(string userText)
        {
            string userTextReverse = string.Empty;
            string[] userTextR = UserTextSplit(userText);
            Array.Reverse(userTextR);
            for(int i = 0; i <= userTextR.Length -1; i++)
            {
                userTextReverse += $"{userTextR[i]} ";
            }
            return userTextReverse;
        }
    }
}
