using Aerospike.Client;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPIDataDumpTool.Controllers
{
    public class ReadTrumpDataController : ApiController
    {
        AerospikeClient aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
        string nameSpace = "AirEngine";
        string setName = "Ankita";

        /// <summary>
        /// http://localhost:54066/GetDataById
        /// Input format in postman example:
        /// {"id1" : 7429102, "id2" : 22012091}
        /// </summary> 
        [HttpPut]
        [Route("GetDataById")]
        public List<Record> GetDataById([FromBody]JObject jsonFormatInput)
        {
            List<Record> output = new List<Record>();
            for (int i = 1; i <= jsonFormatInput.Count; i++)
            {
                string id = jsonFormatInput.GetValue("id" + i).ToString();
                var key = new Key(nameSpace, setName, id.ToString());
                Record dataById = aerospikeClient.Get(new WritePolicy(), key);
                output.Add(dataById);
            }
            return output;
        }

        /// <summary>
        /// http://localhost:54066/UpdateData
        /// Input format in postman example:
        /// {"id" : 7429102,"binName" : "location","newValueOfBin" : "Nagpur" }
        /// </summary>
        [HttpPut]
        [Route("UpdateData")]
        public void UpdateDataById([FromBody]JObject jsonFormatInput)
        {
            List<Record> output = new List<Record>();
            string id = jsonFormatInput.GetValue("id").ToString();
            string binName = jsonFormatInput.GetValue("binName").ToString();
            string newValueOfTheBin = jsonFormatInput.GetValue("newValueOfBin").ToString();
            Bin newBin = new Bin(binName, newValueOfTheBin);
            var key = new Key(nameSpace, setName, id.ToString());
            aerospikeClient.Put(new WritePolicy(), key, newBin);
        }

        /// <summary>
        /// http://localhost:54066/DeleteData/29201047
        /// </summary> 
        [HttpDelete]
        [Route("DeleteData/{id}")]
        public void DeleteDataById(int id)
        {
            var key = new Key(nameSpace, setName, id.ToString());
            aerospikeClient.Delete(new WritePolicy(), key);
        }
    }
}
