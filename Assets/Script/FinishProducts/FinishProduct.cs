using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FinishProduct {

    private List<Prop> components = new List<Prop>();
    private List<int> component_quantity = new List<int>();
    private Sprite image;

    public abstract bool Is_conform_to_component_quantity(string component_name);

    protected abstract void Set_components();

    protected void Set_image(Sprite picture)
    {
        image = picture;
    }

    protected void Set_component(Prop target, int count)
    {
        components.Add(target);
        component_quantity.Add(count);
    }

    public int Get_component_quantity(int number)
    {
        return component_quantity[number];
    }

    public Sprite Get_component_image(int number)
    {
        return components[number].Get_image();
    }

    public int Get_components_count()
    {
        return components.Count;
    }

    public Sprite Get_image()
    {
        return image;
    }
}
