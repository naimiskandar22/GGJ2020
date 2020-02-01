using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class MixerModifierGroup
{
    public string variableName;
    public float value;

    public MixerModifierGroup(string name, float num)
    {
        variableName = name;
        value = num;
    }
}

public class MixerModifierScript : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void RunModifierSet(MixerModifierGroup modifier)
    {
        if (masterMixer == null)
            return;

        if (modifier == null)
            return;

        ModifyMixer(modifier, false);
    }

    public void RunModifierAdd(MixerModifierGroup modifier)
    {
        if (masterMixer == null)
            return;

        if (modifier == null)
            return;

        ModifyMixer(modifier, true);
    }

    public void ModifyMixer(MixerModifierGroup modifier, bool sumup)
    {
        string property = modifier.variableName;
        float currValue;
        bool valid = masterMixer.GetFloat(modifier.variableName, out currValue);

        if (!valid)
            return;

        if(sumup == true)
        {
            currValue += modifier.value;
        }
        else
        {
            currValue = modifier.value;
        }

        masterMixer.SetFloat(property, currValue);
    }
}
