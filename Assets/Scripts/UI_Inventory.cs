using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public GameObject itemSlotC;
    public GameObject itemSlotT;


    private void Awake()
    {
        itemSlotContainer = itemSlotC.transform;
        itemSlotTemplate = itemSlotT.transform;
    }

    

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        //throw new System.NotImplementedException();
        RefreshInventoryItems();
    }

    void Deposit(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotC.transform)
        {
            if (child == itemSlotT.transform) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 120f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotT, itemSlotC.transform).GetComponent<RectTransform>();
            //Debug.Log(itemSlotContainer);

            

            itemSlotRectTransform.gameObject.SetActive(true);
            

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("itemImage").GetComponent<Image>();

            itemSlotRectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => Deposit(20));

            image.sprite = item.GetSprite();
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
            
        }
    }


}
