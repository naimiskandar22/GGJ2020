using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItemLabel
{
    public Item item;
    public int amount;

    public Sprite noteSprite;
    public Sprite noteIcon;
}

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] List<ItemSlot> itemSlots;

    public Item defaultItem;

    public List<InventoryItemLabel> inventoryList = new List<InventoryItemLabel>();
    public List<Item> currMusicCombo = new List<Item>();

    public List<Image> trackDisplayList = new List<Image>();

    //private void OnValidate()
    //{
    //    if (itemsParent != null)
    //    {
    //        ItemSlot[] Temporary = itemsParent.GetComponentsInChildren<ItemSlot>(); ;

    //        for (int i = 0; i < Temporary.Length; i++)
    //        {
    //            itemSlots.Add(Temporary[i]);
    //        }
    //    }
    //}

    private void Start()
    {
        InitializeMusicTrack();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //UpdateList();
        }
    }

    void InitializeMusicTrack()
    {
        if (currMusicCombo.Count > 0)
            return;

        for (int i = 0; i < 5; i++)
        {
            Item item = ScriptableObject.CreateInstance<Item>();

            item = defaultItem;

            currMusicCombo.Add(item);
        }

        UpdateTrack();
    }

    public void UpdateList(Item label)
    {
        for(int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].item.ItemName.Contains(label.ItemName))
            {
                inventoryList[i].amount++;
                break;
            }
        }


        UpdateInventory();

        /*
        ItemSlot slot = new ItemSlot();

        itemSlots.Add(slot);
        */
    }

    void UpdateInventory()
    {
        for(int i = 0; i < itemSlots.Count; i++)
        {
            if(itemSlots[i].Count != null)
            {
                //Update text UI
                itemSlots[i].Count.text = inventoryList[i].amount.ToString();
            }

            if (itemSlots[i].Image != null)
            {
                //Update text UI
                itemSlots[i].Image.sprite = inventoryList[i].noteIcon;
            }
        }
    }

    void UpdateTrack()
    {
        for(int i = 0; i < trackDisplayList.Count; i++)
        {
            if(trackDisplayList[i] != null)
            {
                trackDisplayList[i].sprite = GetItemSprite(currMusicCombo[i]);
            }
        }
    }

    Sprite GetItemSprite(Item type)
    {
        for(int i = 0; i < inventoryList.Count; i++)
        {
            if(inventoryList[i].item.ItemName.Contains(type.ItemName))
            {
                return inventoryList[i].noteSprite;
            }
        }

        return null;
    }

    

}
