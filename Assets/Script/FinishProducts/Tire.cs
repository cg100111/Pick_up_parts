using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : FinishProduct {

    private const int IRON_QUANTITY = 1;
    private const int OIL_QUANTITY = 1;

    private ImageManager image_manager;
    private int oil_count;
    private int iron_count;

    public Tire(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "oil")
            oil_count++;
        else if (component_name == "iron")
            iron_count++;
        if (oil_count >= OIL_QUANTITY && iron_count >= IRON_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Wood(image_manager.Get_component_image((int)PropImage.oil)), OIL_QUANTITY);
        Set_component(new Iron(image_manager.Get_component_image((int)PropImage.iron)), IRON_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.tire));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        oil_count = 0;
        iron_count = 0;
    }
}
