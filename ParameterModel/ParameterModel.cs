using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class ParameterModel
    {
        public string Text { get; set; }

        public float Level { get; set; }

        public string Signature { get; set; }

        public int CardNum { get; set; }

        public static ParameterModel FromString(string input)
        {
            if (input == null)
                return new ParameterModel();
            ParameterModel json = JsonConvert.DeserializeObject<ParameterModel>(input);



            //JavaScriptSerializer js = new JavaScriptSerializer();
            //ParameterModel json = (ParameterModel)js.Deserialize<ParameterModel>(input);
            return json;
        }
    }
}
