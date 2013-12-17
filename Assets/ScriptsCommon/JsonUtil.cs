using System;
using SimpleJson;
public class JsonUtil
{
	public static string Params2Json(params object[] objs){
        JsonArray json = new JsonArray();
        foreach (object obj in objs)
        {
            json.Add(obj);
        }
        return json.ToString();
    }
	public static object[] Json2Params(string str){
        JsonArray objs = (JsonArray)SimpleJson.SimpleJson.DeserializeObject(str);
        return objs.ToArray();
	}
	
}


