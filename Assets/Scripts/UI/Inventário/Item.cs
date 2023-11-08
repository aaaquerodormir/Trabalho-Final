using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public enum ItemType
    {
        caixaDeLeite,
        rato,
        bingBong,
        arranhador,
        ball,
        varinha,

    }

    public ItemType itemType;
    public int amount;

}
