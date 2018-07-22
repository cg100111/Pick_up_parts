using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour {

    public Sprite swatch;
    public Sprite chear;
    public Sprite table;
    public Sprite window;
    public Sprite knife;
    public Sprite glasses;
    public Sprite key;
    public Sprite trashcan;
    public Sprite tire;

    public Sprite gear;
    public Sprite wood;
    public Sprite screw;
    public Sprite iron;
    public Sprite glass;
    public Sprite oil;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Sprite Get_finish_product_image(int number)
    {
        if (number == 1)
            return swatch;
        else if (number == 2)
            return chear;
        else if (number == 3)
            return table;
        else if (number == 4)
            return window;
        else if (number == 5)
            return knife;
        else if (number == 6)
            return glasses;
        else if (number == 7)
            return key;
        else if (number == 8)
            return trashcan;
        else if (number == 9)
            return tire;
        else
            return null;
    }

    public Sprite Get_component_image(int number)
    {
        if (number == 1)
            return gear;
        else if (number == 2)
            return wood;
        else if (number == 3)
            return screw;
        else if (number == 4)
            return iron;
        else if (number == 5)
            return glass;
        else if (number == 6)
            return oil;
        else
            return null;
    }
}
