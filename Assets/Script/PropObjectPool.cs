using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropObjectPool : MonoBehaviour {

    public GameObject prop_sample;
    public int max_count;

    private List<GameObject> used_prop;
    private List<GameObject> unuse_prop;

    void Awake()
    {
        used_prop = new List<GameObject>();
        unuse_prop = new List<GameObject>();
        Create();
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Create()
    {
        for (int num = 0; num < max_count; num++)
        {
            GameObject prop = Instantiate(prop_sample);
            prop.transform.parent = this.transform;
            prop.transform.localPosition = prop_sample.transform.localPosition;
            prop.SetActive(false);
            unuse_prop.Add(prop);
        }
    }

    public void Use()
    {
        if (unuse_prop.Count > 0)
        {
            unuse_prop[0].SetActive(true);
            used_prop.Add(unuse_prop[0]);
            unuse_prop.RemoveAt(0);
        }
    }

    public void Unuse_all_prop()
    {
        if (used_prop.Count > 0)
            while (used_prop.Count > 0)
                Unuse(used_prop[0]);
    }

    private void Unuse(GameObject prop)
    {
        used_prop.Remove(prop);
        prop.SetActive(false);
        prop.GetComponent<Rigidbody>().useGravity = false;
        prop.GetComponent<Rigidbody>().velocity = Vector3.zero;
        prop.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        prop.transform.localPosition = prop_sample.transform.localPosition;
        unuse_prop.Add(prop);
    }
}
