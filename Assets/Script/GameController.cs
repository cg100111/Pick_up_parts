using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController ui_controller;
    public Adjustment adjuster;
    public PropController[] prop_controllers;
    public RobotManager robot_manager;
    public ComponentsController components_controller;

    private float time;
    private int quantity_of_finishProduct;
    private bool is_start;

	// Use this for initialization
	void Start () {
        Original();
        Change_to_first_person();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
            Start_game();
        if (is_start)
        {
            timer_count_down();
            if (time <= 0)
                Stop_game();
        }
    }

    public void Original()
    {
        Initialize();
        ui_controller.Description_mode();
    }

    public void Start_game()
    {
        is_start = true;
        ui_controller.Start_mode();
        ui_controller.Update_Timer(time.ToString());
        ui_controller.Update_number_of_completed(quantity_of_finishProduct.ToString());
        components_controller.Change_position();
        Reset_props();
    }

    public void Adjust()
    {
        ui_controller.Adjustment_mode();
        adjuster.Start_adjust();
    }

    public void Add_quantity_of_finishProduct()
    {
        quantity_of_finishProduct++;
        ui_controller.Update_number_of_completed(quantity_of_finishProduct.ToString());
    }

    public void Reset_props()
    {
        foreach (PropController controller in prop_controllers)
        {
            controller.Recycle_all_prop();
            controller.Create_sample();
        }
    }

    public void Change_to_first_person()
    {
        robot_manager.Set_first_person(true);
    }

    public void Change_to_third_person()
    {
        robot_manager.Set_first_person(false);
    }

    private void Initialize()
    {
        is_start = false;
        time = 60f;
        quantity_of_finishProduct = 0;
    }

    private void timer_count_down()
    {
        time -= Time.deltaTime;
        ui_controller.Update_Timer(time.ToString());
    }

    private void Stop_game()
    {
        is_start = false;
        Reset_props();
        ui_controller.End_mode(quantity_of_finishProduct.ToString());
    }

    public bool Is_start
    {
        get
        {
            return is_start;
        }
    }
}
