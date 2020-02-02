using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComboScript : MonoBehaviour
{
    public int currComboIndex = 0;

    public int[] trackComboArrangement = new int[5] { 1, 0, 3, 0, 5 };

    public int currPlaylistIndex = 0;
    public float playDuration;
    public float trackInterval;

    public AudioClip completeTrack;

    public TrackSlot[] trackSlotList;

    public GameObject objectToEnable;


    // Start is called before the first frame update
    void Start()
    {
        if(completeTrack != null)
        {
            trackInterval = completeTrack.length / 5;
        }

        PlayComboAudio();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlaylist();
    }

    public void CheckTrackCompletion()
    {
        bool levelCompleted = true;

        for(int i = 0; i < trackComboArrangement.Length; i++)
        {
            if(trackComboArrangement[i] == 0)
            {
                levelCompleted = false;
            } 
        }

        if(levelCompleted)
        {
            if(objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }
        }
    }

    public void CheckPlaylist()
    {
        playDuration += Time.deltaTime;

        if(playDuration >= trackInterval)
        {
            currComboIndex++;
            playDuration = 0.0f;

            if (currComboIndex >= trackComboArrangement.Length)
            {
                currComboIndex = 0;
            }

            PlayComboAudio();
        }
    }

    public void PlayComboAudio()
    {
        int indexCheck = currPlaylistIndex;

        playDuration = 0.0f;
        currPlaylistIndex = trackComboArrangement[currComboIndex];

        if(currPlaylistIndex > 0)
        {
            SoundManagerScript.instance.bgmAudioSource.mute = false;
            
            if(indexCheck + 1 != currPlaylistIndex)
                SoundManagerScript.instance.bgmAudioSource.time = trackInterval * trackComboArrangement[currPlaylistIndex - 1];
        }
        else
        {
            SoundManagerScript.instance.bgmAudioSource.mute = true;
        }

    }

    public int GetTrackIndex(TrackSlot trackSlot)
    {
        for (int i = 0; i < trackSlotList.Length; i++)
        {
            if(trackSlotList[i] == trackSlot)
            {
                return i;
            }
        }

        return 0;
    }
}
