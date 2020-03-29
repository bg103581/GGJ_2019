using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    public void SetVolume(float vol) {
        AudioListener.volume = vol;
    }
}
