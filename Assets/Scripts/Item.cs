using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Phone,
        Clarinet,
        Bottel,
        Map,
        Sock,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Bottel: return ItemAssets.Instance.bottelSprite;
            case ItemType.Phone: return ItemAssets.Instance.phoneSprite;
            case ItemType.Clarinet: return ItemAssets.Instance.clarinetSprite;
            case ItemType.Map: return ItemAssets.Instance.mapSprite;
            case ItemType.Sock: return ItemAssets.Instance.sockSprite;
        }
    }
}
