using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjustment : MonoBehaviour {

    private const float DISTANCE = 0.02f;

    public GameObject hand;
    public GameObject body;
    public GameObject wall;

    private bool start;
    private float max_position;
    private float min_position;

	// Use this for initialization
	void Start () {
        start = false;
        max_position = 0;
        min_position = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
            Adjust();
    }

    public void Start_adjust()
    {
        start = true;
    }

    private void Adjust()
    {
        if (hand.transform.position.z > max_position)
            max_position = hand.transform.position.x;
        if (hand.transform.position.z < min_position)
            min_position = hand.transform.position.z;
    }

    private void Set_position()
    {
        body.transform.position.Set(0, 0, min_position + DISTANCE);
        wall.transform.position.Set(0, 0, max_position - DISTANCE);
    }
}
