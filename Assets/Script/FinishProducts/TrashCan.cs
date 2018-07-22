using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : FinishProduct {

    private const int OIL_QUANTITY = 4;

    private ImageManager image_manager;
    private int oil_count;

    public TrashCan(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "oil")
            oil_count++;
        if (oil_count >= OIL_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Iron(image_manager.Get_component_image((int)PropImage.oil)), OIL_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.trashcan));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        oil_count = 0;
    }
}
