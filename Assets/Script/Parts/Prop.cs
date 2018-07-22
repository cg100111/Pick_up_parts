using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prop {

    private Sprite image;

    protected void Set_image(Sprite picture)
    {
        image = picture;
    }

    public Sprite Get_image()
    {
        return image;
    }
}
