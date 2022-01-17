using Newtonsoft.Json.Linq;

namespace JSON_Value_Retriever
{
    public class JSONReader
    {
        private string _JSONString;
        private JObject _JSONObject;

        public JSONReader()
        {

        }

        #region Private Methods
        private void ParseJSON(string json)
        {
            try
            {
                _JSONObject = JObject.Parse(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates and initializes a JSONReader object from a json string
        /// </summary>
        static public JSONReader ParseJson(string json)
        {
            JSONReader reader = new JSONReader();
            try
            {
                reader.ParseJSON(json);
            }
            catch (Exception)
            {
                throw;
            }
            return reader;
        }

        /// <summary>
        /// Creates and initializes a JSONReader object from a path leading to JSON file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public JSONReader ParseJsonPath(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    JSONReader reader = JSONReader.ParseJson(json);

                    return reader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetValue(string key)
        {
            if (_JSONObject == null)
            {
                return "Empty JSON";
            }
            else
            {
                try
                {
                    var value = _JSONObject.GetValue(key);
                    return value?.ToString() ?? "Not Found...";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion
    }
}
