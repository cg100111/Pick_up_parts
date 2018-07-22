using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum FinishProductImage
{
    swatch = 1,
    chear,
    table,
    window,
    knife,
    glasses,
    key,
    trashcan,
    tire,
};

enum PropImage
{
    gear = 1,
    wood,
    screw,
    iron,
    glass,
    oil,
};

public class ProductionSystem : MonoBehaviour {

    public GameController game_controller;
    public Image UI_target;
    public Image[] UI_components;
    public ImageManager image_manager;
    
    private List<FinishProduct> targets;
    private int now_target;

	// Use this for initialization
	void Start () {
        now_target = -1;
        targets = new List<FinishProduct>();
        Set_finish_products();
        Reset_UI_components_image();
        Change_target();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Change_target();
        }
	}

    public void Check_is_conform_to_target(string component)
    {
        if (targets[now_target].Is_conform_to_component_quantity(component))
        {
            game_controller.Reset_props();
            Change_target();
            game_controller.Add_quantity_of_finishProduct();
        }
    }

    private void Change_target()
    {
        int next_target = Get_next_target();
        now_target = next_target;
        Change_image();
    }

    private void Set_finish_products()
    {
        targets.Add(new Swatch(image_manager));
        targets.Add(new Chear(image_manager));
        targets.Add(new Table(image_manager));
        targets.Add(new Window(image_manager));
        targets.Add(new Knife(image_manager));
        targets.Add(new Glasses(image_manager));
        targets.Add(new Key(image_manager));
        targets.Add(new TrashCan(image_manager));
        targets.Add(new Tire(image_manager));
    }

    private int Get_next_target()
    {
        int new_target;
        do
        {
            new_target = UnityEngine.Random.Range(0, targets.Count);
        } while (now_target == new_target);
        return new_target;
    }

    private void Change_image()
    {
        UI_target.sprite = targets[now_target].Get_image();
        Reset_UI_components_image();
        Change_components_image();
    }

    private void Reset_UI_components_image()
    {
        foreach(Image image in UI_components)
            image.gameObject.SetActive(false);
    }

    private void Change_components_image()
    {
        for(int count = 0; count < targets[now_target].Get_components_count(); count++)
        {
            UI_components[count].gameObject.SetActive(true);
            UI_components[count].sprite = targets[now_target].Get_component_image(count);
            UI_components[count].GetComponentInChildren<Text>().text = "x" + targets[now_target].Get_component_quantity(count);
        }
    }
}
