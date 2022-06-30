using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New False Primary Item", menuName = "Inventory System/Item/False Primary")]
public class FalsePrimaryItem : Item
{
    private void Awake()
    {
        itemType = ItemType.FalsePrimary;
    }
    public override Hand CheckEquibility(ItemManager itemManager)
    {
        if (!itemManager.righthand_item)
        {
            var return_val = itemManager.lefthand_item?.itemType != ItemType.Secondary ? Hand.Right : Hand.None;
            return return_val;
        }
        else if (!itemManager.lefthand_item && itemManager?.righthand_item.slotSpace == SlotSpace.OneHanded)
            return Hand.Left;

        return Hand.None;
    }
}
