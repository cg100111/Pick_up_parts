using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : FinishProduct {

    private const int WOOD_QUANTITY = 3;
    private const int SCREW_QUANTITY = 4;
    private const int IRON_QUANTITY = 2;

    private ImageManager image_manager;
    private int wood_count;
    private int screw_count;
    private int iron_count;

    public Table(ImageManager manager)
    {
        image_manager = manager;
        Initialize();
    }

    public override bool Is_conform_to_component_quantity(string component_name)
    {
        if (component_name == "wood")
            wood_count++;
        else if (component_name == "screw")
            screw_count++;
        else if (component_name == "iron")
            iron_count++;
        if (wood_count >= WOOD_QUANTITY && screw_count >= SCREW_QUANTITY && iron_count >= IRON_QUANTITY)
        {
            Reset_component_quantity();
            return true;
        }
        return false;
    }

    protected override void Set_components()
    {
        Set_component(new Wood(image_manager.Get_component_image((int)PropImage.wood)), WOOD_QUANTITY);
        Set_component(new Screw(image_manager.Get_component_image((int)PropImage.screw)), SCREW_QUANTITY);
        Set_component(new Iron(image_manager.Get_component_image((int)PropImage.iron)), IRON_QUANTITY);
    }

    private void Initialize()
    {
        Set_image(image_manager.Get_finish_product_image((int)FinishProductImage.table));
        Set_components();
        Reset_component_quantity();
    }

    private void Reset_component_quantity()
    {
        wood_count = 0;
        screw_count = 0;
        iron_count = 0;
    }
}
