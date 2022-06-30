using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Secondary Item", menuName = "Inventory System/Item/Secondary")]
public class SecondaryItem : Item
{
    private void Awake()
    {
        itemType = ItemType.Secondary;
    }
    public override Hand CheckEquibility(ItemManager itemManager)
    {
        if (!itemManager.lefthand_item)
        {
            var return_val = itemManager.righthand_item?.slotSpace == SlotSpace.TwoHanded ? Hand.None : Hand.Left;
            return return_val;
        }   
        else
            return Hand.None;
    }
}
