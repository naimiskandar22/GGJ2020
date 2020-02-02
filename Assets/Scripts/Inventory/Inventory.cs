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
            //DontDestroyOnLoad(this.gameObject);
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

    public string[] musicTrackLabels;
    public int currTrackIndex = 0;

    public Material grayscaleMat;

    MusicComboScript comboContainer;


    bool goodSequence = false;

    public GameObject winPrompt;
    public GameObject losePrompt;

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
        GameObject go = GameObject.FindGameObjectWithTag("SoundManager");

        comboContainer = go.GetComponent<MusicComboScript>();

        InitializeMusicTrack();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //UpdateList(defaultItem);
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

        SetTrackIndex(currTrackIndex + 1);

        UpdateInventory();
        //UpdateMusicTrack(0.0f);
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

    public void UpdateTrack()
    {
        for(int i = 0; i < trackDisplayList.Count; i++)
        {
            if(trackDisplayList[i] != null)
            {
                trackDisplayList[i].material = (comboContainer.trackComboArrangement[i] == 0 ? grayscaleMat : null);
            }
        }
    }

    void SetTrackIndex(int value)
    {
        currTrackIndex = value;
    }


    public void CheckCombo()
    {
        goodSequence = true;

        for (int i = 1; i < comboContainer.trackComboArrangement.Length; i++)
        {
            if (comboContainer.trackComboArrangement[i] - comboContainer.trackComboArrangement[i - 1] != 1)
            {
                goodSequence = goodSequence && false;
            }
        }

        if (goodSequence == true)
        {
            if (winPrompt != null)
            {
                winPrompt.SetActive(true);
                losePrompt.SetActive(false);
            }
        }
        else
        {
            if (losePrompt != null)
            {
                losePrompt.SetActive(true);
                winPrompt.SetActive(false);
            }
        }
    }


    /*
    void UpdateMusicTrack(float value)
    {
        if (currTrackIndex <= 0)
            return;

        

        for(int i = 0; i < currTrackIndex; i++)
        {
            if (i >= musicTrackLabels.Length)
                break;

            MixerModifierGroup mixGroup = new MixerModifierGroup(musicTrackLabels[i], value);

            modifier.ModifyMixer(mixGroup, false);
        }
    }
    */

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
