using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour {

    public PropObjectPool object_pool;

	// Use this for initialization
	void Start () {
        object_pool.Use();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit(Collider col)
    {
        Debug.Log("exit, col : " + col.name);
        if (col.tag == this.transform.GetChild(0).tag)
            object_pool.Use();
    }

    public void Recycle_all_prop()
    {
        object_pool.Unuse_all_prop();
    }

    public void Create_sample()
    {
        object_pool.Use();
    }
}
