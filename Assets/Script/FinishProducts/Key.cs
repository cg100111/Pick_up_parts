using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : FinishProduct {

    private const int IRON_QUANTITY = 1;

    private ImageManager image_manager;
    private int iron_count;

    public Key(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "iron")
            iron_count++;
        if (iron_count >= IRON_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Iron(image_manager.Get_component_image((int)PropImage.iron)), IRON_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.key));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        iron_count = 0;
    }
}
