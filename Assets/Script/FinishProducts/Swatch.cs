using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatch : FinishProduct {

    private const int GEAR_QUANTITY = 5;

    private ImageManager image_manager;
    private int gear_count;

    public Swatch(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "gear")
            gear_count++;
        if (gear_count >= GEAR_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Gear(image_manager.Get_component_image((int)PropImage.gear)), GEAR_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.swatch));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        gear_count = 0;
    }
}
