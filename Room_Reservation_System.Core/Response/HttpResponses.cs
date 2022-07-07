using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Response
{
    public static  class HttpResponses
    {
        /// <summary>
        /// this method used to return a json response by return  a dictionary hold the data
        /// </summary>
        /// <param name="ResponseData"></param>
        /// <returns></returns>
        public static Dictionary<string, object> Success(params (string key,object value )[] ResponseData) 
        {
            Dictionary<string, object> Response = new();
            Response.Add("State", "Done");
            for (int index = 0; index < ResponseData.Length; index++)
            {
                (string key, object value) Data = ResponseData[index];
                Response.Add(Data.key, Data.value);
            }
            return Response;
        }
    }
}
