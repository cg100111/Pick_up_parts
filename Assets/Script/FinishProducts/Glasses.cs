using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : FinishProduct {

    private const int GLASS_QUANTITY = 1;
    private const int IRON_QUANTITY = 1;

    private ImageManager image_manager;
    private int glass_count;
    private int iron_count;

    public Glasses(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "glass")
            glass_count++;
        else if (component_name == "iron")
            iron_count++;
        if (glass_count >= GLASS_QUANTITY && iron_count >= IRON_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Glass(image_manager.Get_component_image((int)PropImage.glass)), GLASS_QUANTITY);
        Set_component(new Iron(image_manager.Get_component_image((int)PropImage.iron)), IRON_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.glasses));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        glass_count = 0;
        iron_count = 0;
    }
}
