using UnityEngine;
using System.Collections;
using core;
public class Main : MonoBehaviour
{

    // Use this for initialization
    public static Main Inst = null;
    void Start()
    {
        Inst = this;
        DontDestroyOnLoad(gameObject);
        initModules();
    }
    private void initModules()
    {
		//ModuleMgr.Ins.AddModule(new InputMod());
        ModuleMgr.Inst.Start();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }
		ModuleMgr.Inst.Update();
    }
    void OnApplicationQuit()
    {
		ModuleMgr.Inst.Dispose();
    }
}
