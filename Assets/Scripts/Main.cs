using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
    public static Main Inst = null;
    private ModuleMgr _moduleMgr = ModuleMgr.Instance();
	void Start () {
        Inst = this;
        DontDestroyOnLoad(gameObject);
        initModules();
	}
    private void initModules()
    {
        //_moduleMgr.AddModule(new InputMod());
        _moduleMgr.Start();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }
        _moduleMgr.Update();
	}
    void OnApplicationQuit()
    {
        //_moduleMgr.OnQuit();
    }
}
