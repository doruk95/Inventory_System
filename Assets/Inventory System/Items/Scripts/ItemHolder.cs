using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [HideInInspector] public Item item;
    private Button button;
    public ItemManager itemManager;

    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { itemManager.OnClickedItem(this); });
    }
}
