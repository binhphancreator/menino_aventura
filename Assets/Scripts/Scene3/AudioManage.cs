using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    public  AudioClip Sound;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        // Sound = Resources.Load<AudioClip>("Sound/jump");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip){
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(Sound);
                break;
        }
    }
}
