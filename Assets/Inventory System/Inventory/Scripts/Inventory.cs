using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>();

    private List<Item> backup = new List<Item>();

    public void AddItem(Item added_item)
    {
        items.Add(added_item);
    }

    public void DropItem(Item dropped_item)
    {
        items?.Remove(dropped_item);
    }
}
