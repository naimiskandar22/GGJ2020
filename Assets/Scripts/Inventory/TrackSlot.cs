using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrackSlot : MonoBehaviour, IDropHandler
{
    public bool canBind = false;

    public Image trackDisplay;
    public Material grayscaleMat;

    public Image boundTrack;
    public int comboIndex;

    MusicComboScript comboHandler;
    public bool playedDetachOnce = false;

    GameObject pointerData;

    void Start()
    {
        playedDetachOnce = false;

        GameObject go = GameObject.FindGameObjectWithTag("SoundManager");

        comboHandler = go.GetComponent<MusicComboScript>();

        if (canBind == false)
            trackDisplay.raycastTarget = false;

        trackDisplay.material = (comboHandler.trackComboArrangement[comboHandler.GetTrackIndex(this)] == 0 ? grayscaleMat : null);
    }

    void Update()
    {
        if (boundTrack == null)
            return;

        CheckTrackBound();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (canBind == false)
            return;

        if (eventData.pointerDrag != null)
        {
            pointerData = eventData.pointerDrag;

            Invoke("AttachTrack", Time.deltaTime / 2.0f);
        }
    }

    void AttachTrack()
    {
        pointerData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        boundTrack = pointerData.GetComponent<Image>();
        trackDisplay.material = null;
        trackDisplay.raycastTarget = false;

        DragnDrop dnd = pointerData.GetComponent<DragnDrop>();

        if (dnd)
        {
            comboIndex = dnd.comboIndex;
        }

        UpdateTrackCombo();
        pointerData = null;
    }

    void CheckTrackBound()
    {
        if(Vector2.Distance(boundTrack.rectTransform.anchoredPosition, GetComponent<RectTransform>().anchoredPosition) > 30.0f)
        {
            if (playedDetachOnce == true)
                return;

            playedDetachOnce = true;
            DetachTrack();
        }
    }

    void DetachTrack()
    {
        comboIndex = 0;
        boundTrack = null;

        trackDisplay.material = grayscaleMat;
        trackDisplay.raycastTarget = true;
        
        UpdateTrackCombo();

        playedDetachOnce = false;
    }

    void UpdateTrackCombo()
    {
        int index = comboHandler.GetTrackIndex(this);
        
        if (comboHandler != null)
        {
            comboHandler.trackComboArrangement[index] = comboIndex;
        }

        if(Inventory.instance != null)
        {
            //Inventory.instance.trackDisplayList[index].material = (comboIndex == 0 ? grayscaleMat : null);
            Inventory.instance.UpdateTrack();

        }

        comboHandler.CheckTrackCompletion();
    }

    
}
