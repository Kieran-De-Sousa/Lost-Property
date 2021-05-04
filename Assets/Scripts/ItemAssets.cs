using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite bottelSprite;
    public Sprite phoneSprite;
    public Sprite mapSprite;
    public Sprite clarinetSprite;
    public Sprite sockSprite;
}
