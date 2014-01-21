#pragma warning disable 3001,3024

using UnityEngine;
using System.Collections.Generic;
namespace core
{
    public class UIHelper
    {
        public static T Show<T>(string prefab) where T : Component
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(prefab), Vector3.zero, Quaternion.identity) as GameObject;
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