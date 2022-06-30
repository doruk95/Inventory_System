using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotSpace { OneHanded, TwoHanded }
public enum Hand {Left, Right, None}
public enum ItemType {Primary, Secondary, FalsePrimary}
public abstract class Item : ScriptableObject
{
    public ItemType itemType;
    public SlotSpace slotSpace;

    public abstract Hand CheckEquibility(ItemManager itemManager);
}

