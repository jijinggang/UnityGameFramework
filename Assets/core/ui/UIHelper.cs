using UnityEngine;
using System.Collections.Generic;
namespace core
{
    public class UIHelper
    {
        public static T Show<T>(string prefab) where T : Component
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(prefab), new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            return obj.AddComponent<T>();
        }
        public static void Close(GameObject obj)
        {
            GameObject.DestroyObject(obj);
        }
        //public static void SetButtonText(UIButton btn, string text)
        //{
        //    btn.transform.Find("Label").GetComponent<UILabel>().text = text;
        //}
    }
}