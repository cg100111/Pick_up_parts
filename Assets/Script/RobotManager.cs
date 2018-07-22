using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour {

    public GameObject head;
    public BoxCollider[] hands_collider;

    private bool is_first_person;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Set_position();
        Set_rotation();
    }

    public void Set_first_person(bool value)
    {
        is_first_person = value;
        if (!is_first_person)
            Open_collider();
    }

    private void Set_position()
    {
        if (is_first_person)
            At_first_person();
        else
            At_third_person();
    }

    private void Set_rotation()
    {
        transform.rotation = Quaternion.Euler(0, head.transform.rotation.eulerAngles.y, 0);
    }

    private void At_first_person()
    {
        transform.position = new Vector3(head.transform.position.x, 0f, head.transform.position.z);
        Is_player_outside_the_area();
    }

    private void At_third_person()
    {
        Vector3 robot_pos = new Vector3(head.transform.position.x, 0f, head.transform.position.z);
        if (head.transform.position.x > 0.5)
            robot_pos.x = 0.5f;
        else if (head.transform.position.x < -0.5)
            robot_pos.x = -0.5f;
        if (head.transform.position.z > 0.5)
            robot_pos.z = 0.5f;
        else if (head.transform.position.z < -0.5)
            robot_pos.z = -0.5f;
        transform.position = robot_pos;
    }

    private void Is_player_outside_the_area()
    {
        if (head.transform.position.x > 0.5)
            Close_collider();
        else if (head.transform.position.x < -0.5)
            Close_collider();
        if (head.transform.position.z > 0.5)
            Close_collider();
        else if (head.transform.position.z < -0.5)
            Close_collider();
        else
            Open_collider();
    }

    private void Close_collider()
    {
        foreach (BoxCollider collider in hands_collider)
            collider.enabled = false;
    }

    private void Open_collider()
    {
        foreach (BoxCollider collider in hands_collider)
            collider.enabled = true;
    }
}
