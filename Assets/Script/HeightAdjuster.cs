using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightAdjuster : MonoBehaviour {

    public Text height_ui;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Update_height(string height)
    {
        height_ui.text = "Height : " + height+"cm";
    }
}
