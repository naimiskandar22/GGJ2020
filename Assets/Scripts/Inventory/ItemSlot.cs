using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image Image;
    public Text Count;
    public int Amount = 0;
    public Item Type;

    //private Item _item;
    //public Item Item
    //{
    //    get { return _item; }
    //    set
    //    {
    //        _item = value;

    //        if (_item == null)
    //        {
    //            Image.enabled = false;
    //        } else
    //        {
    //            Image.sprite = _item.Icon;
    //            Image.enabled = true;
    //        }
    //    }
    //}
    //private void OnValidate()
    //{
    //    if (Image == null)
    //        Image = GetComponent<Image>();
    //}
}
