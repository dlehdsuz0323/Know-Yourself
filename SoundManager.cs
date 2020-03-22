using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    //public static SoundManager GetInstance()
    //{
    //    return instance;
    //}


    public List<AudioClip> audioList;
    private AudioSource audioSource;


    private void Awake()
    {
        instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
        //DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;

        audioSource = GetComponent<AudioSource>();
        object[] temp = Resources.LoadAll("__Sound");
        for(int i =0; i< temp.Length; i++)
            audioList.Add(temp[i] as AudioClip);
        PlayAudio("Fear_Short");
    }


    public void PlayAudio(string audioFileName)
    {
         for(int i = 0; i< audioList.Count; i++)
        {
            if(audioList[i].name == audioFileName)
            {
                audioSource.clip = audioList[i];
                audioSource.Play();
            }
        }
    }


    public void PauseAudio(string audioFileName)
    {
        for (int i = 0; i < audioList.Count; i++)
        {
            if (audioList[i].name == audioFileName)
            {
                audioSource.clip = audioList[i];
                audioSource.Pause();
            }
        }
    }


    public void StopAudio(string audioFileName)
    {
        for (int i = 0; i < audioList.Count; i++)
        {
            if (audioList[i].name == audioFileName)
            {
                audioSource.clip = audioList[i];
                audioSource.Stop();
            }
        }
    }
}