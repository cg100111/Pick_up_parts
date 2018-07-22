using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandLimit : MonoBehaviour {

    public GameObject head;

    private BoxCollider my_collider;
    private bool is_first_person;

    void Awake()
    {
        my_collider = GetComponent<BoxCollider>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (is_first_person)
            Is_player_outside_the_area();
    }

    public void Set_person(bool is_first)
    {
        is_first_person = is_first;
    }

    private void Is_player_outside_the_area()
    {
        if (head.transform.position.x > 0.5f)
            Close_collider();
        else if (head.transform.position.x < -0.5f)
            Close_collider();
        else if (head.transform.position.z > 0.5f)
            Close_collider();
        else if (head.transform.position.z < -0.5f)
            Close_collider();
        else
            Open_collider();
    }

    private void Close_collider()
    {
        my_collider.enabled = false;
    }

    private void Open_collider()
    {
        my_collider.enabled = true;
    }
}
