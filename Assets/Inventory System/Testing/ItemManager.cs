using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject itemview_pref;
    [SerializeField] Transform inventory_view;
    [Space]
    [SerializeField] Button righthand_button;
    [SerializeField] Button lefthand_button;
    [Space]
    [SerializeField] GameObject equip_Button;
    #endregion

    #region Public Fields
    [HideInInspector]public Item righthand_item;
    [HideInInspector]public Item lefthand_item;
    #endregion

    private (Hand, Item) current_Selected = (Hand.None, null);

    private void Awake()
    {
        foreach (var item in inventory.items)
        {
            var instantiatedItem = Instantiate(itemview_pref, inventory_view);
            instantiatedItem.GetComponent<ItemHolder>().item = item;
            instantiatedItem.name = item.name;
            instantiatedItem.GetComponentInChildren<TMP_Text>().text = item.name;
        }
    }

    public void ClearHand(bool is_rigth)
    {
        if (is_rigth)
        {
            righthand_item = null;
            righthand_button.GetComponentInChildren<TMP_Text>().text = "Empty";
        }
        else
        {
            lefthand_item = null;
            lefthand_button.GetComponentInChildren<TMP_Text>().text = "Empty";
        }
        equip_Button.SetActive(false);
    }

    public void OnClickedItem(ItemHolder item_holder)
    {
        current_Selected.Item2 = item_holder.item;
        equip_Button.GetComponent<Button>().interactable = false;
        equip_Button.transform.SetParent(item_holder.transform);
        var offset = equip_Button.GetComponent<RectTransform>().rect.height / 2 + item_holder.GetComponent<RectTransform>().rect.height / 2;

        equip_Button.transform.position = item_holder.transform.position + new Vector3(0, -offset ,0);

        current_Selected.Item1 = item_holder.item.CheckEquibility(this);
        if (current_Selected.Item1 != Hand.None)
            equip_Button.GetComponent<Button>().interactable = true;
        equip_Button.SetActive(true);
    }

    public void Equip()
    {
        switch (current_Selected.Item1)
        {
            case Hand.Right:
                righthand_item = current_Selected.Item2;
                righthand_button.GetComponentInChildren<TMP_Text>().text = righthand_item.name;
                break;
            case Hand.Left:
                lefthand_item = current_Selected.Item2;
                lefthand_button.GetComponentInChildren<TMP_Text>().text = lefthand_item.name;
                break;
        }
        equip_Button.SetActive(false);
        current_Selected = (Hand.None, null);
    }
}