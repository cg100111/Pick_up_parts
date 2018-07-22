using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryField : MonoBehaviour {

    public ProductionSystem product_system;
    public GameController game_controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (game_controller.Is_start)
            product_system.Check_is_conform_to_target(other.tag);
    }
}
