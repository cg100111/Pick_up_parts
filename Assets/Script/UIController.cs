using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject start_button;
    public GameObject adjustment_button;
    public GameObject confirm_button;
    public GameObject height_adjuser;
    public WhiteboardController whiteboard_controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Description_mode()
    {
        start_button.SetActive(true);
        adjustment_button.SetActive(false);
        confirm_button.SetActive(false);
        height_adjuser.SetActive(true);
        whiteboard_controller.Change_to_explain_game();
    }

    public void Start_mode()
    {
        start_button.SetActive(false);
        adjustment_button.SetActive(false);
        confirm_button.SetActive(false);
        height_adjuser.SetActive(false);
        whiteboard_controller.Change_to_target();
    }

    public void Adjustment_mode()
    {
        start_button.SetActive(true);
        adjustment_button.SetActive(false);
        confirm_button.SetActive(false);
        height_adjuser.SetActive(false);
        whiteboard_controller.Change_to_explain_adjustment();
    }

    public void End_mode(string count)
    {
        start_button.SetActive(false);
        adjustment_button.SetActive(false);
        confirm_button.SetActive(true);
        height_adjuser.SetActive(false);
        whiteboard_controller.Change_to_display_result(count);
    }

    public void Update_Timer(string time)
    {
        whiteboard_controller.Update_time(time);
    }

    public void Update_number_of_completed(string number)
    {
        whiteboard_controller.Update_number_of_completed(number);
    }

    public void Update_height(string height)
    {
        height_adjuser.GetComponent<HeightAdjuster>().Update_height(height);
    }
}
