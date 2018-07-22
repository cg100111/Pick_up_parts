using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsController : MonoBehaviour {

    public GameObject[] components;

    private List<Vector3> unused_positions;
    private List<Vector3> used_positions;

	// Use this for initialization
	void Start () {
        unused_positions = new List<Vector3>();
        used_positions = new List<Vector3>();
        Create_positions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change_position()
    {
        Reset_position();
        foreach (GameObject target in components)
        {
            int pos_number = Get_random_position();
            target.SetActive(false);
            target.transform.localPosition = unused_positions[pos_number];
            target.SetActive(true);
            used_positions.Add(unused_positions[pos_number]);
            unused_positions.RemoveAt(pos_number);
        }
    }

    private void Create_positions()
    {
        unused_positions.Add(new Vector3(0f, 0f, 1.5f));
        unused_positions.Add(new Vector3(1f, 0f, 1.5f));
        unused_positions.Add(new Vector3(-1f, 0f, 1.5f));
        unused_positions.Add(new Vector3(0f, 0f, -1.5f));
        unused_positions.Add(new Vector3(1f, 0f, -1.5f));
        unused_positions.Add(new Vector3(-1f, 0f, -1.5f));
        unused_positions.Add(new Vector3(1.5f, 0f, 0f));
        unused_positions.Add(new Vector3(1.5f, 0f, 1f));
        unused_positions.Add(new Vector3(1.5f, 0f, -1f));
        unused_positions.Add(new Vector3(-1.5f, 0f, 0f));
        unused_positions.Add(new Vector3(-1.5f, 0f, 1f));
        unused_positions.Add(new Vector3(-1.5f, 0f, -1f));
    }

    private void Reset_position()
    {
        while (used_positions.Count > 0)
        {
            unused_positions.Add(used_positions[0]);
            used_positions.RemoveAt(0);
        }
    }

    private int Get_random_position()
    {
        return Random.Range(0, unused_positions.Count - 1);
    }
}
