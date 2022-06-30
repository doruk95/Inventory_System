using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Primary Item", menuName = "Inventory System/Item/Primary")]
public class PrimaryItem : Item
{
    private void Awake()
    {
        itemType = ItemType.Primary;
    }

    public override Hand CheckEquibility(ItemManager itemManager)
    {
        switch (slotSpace)
        {
            case SlotSpace.OneHanded:
                if (!itemManager.righthand_item)
                    return Hand.Right;
                else if (!itemManager.lefthand_item && itemManager.righthand_item.slotSpace == SlotSpace.OneHanded)
                    return Hand.Left;
                break;
            case SlotSpace.TwoHanded:
                if (!itemManager.righthand_item && !itemManager.lefthand_item)
                    return Hand.Right;
                break;
        }
        return Hand.None;
    }
}
