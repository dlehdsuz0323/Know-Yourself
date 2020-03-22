using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBoxLockedSingleton : MonoBehaviour
{
    Animation ChestAnimator;
    Animation LockDigitsAnimator;
    public GameObject ChildChest;
    public bool AnimaLoop;
    public static ChestBoxLockedSingleton instance;
    public int[] LockDigits = new int[3];
    public bool chestQuizClear;
    public Text[] ChestPassword = new Text[3];

    [Header("정답 339")] 
    public int NumberPad1 = 0;
    public int NumberPad2 = 0;
    public int NumberPad3 = 0;
                          
    public int   Angles_z_1  = 0;
    public float fAngles_z_1 = 0;
    public int   Angles_z_2  = 0;
    public float fAngles_z_2 = 0;
    public int   Angles_z_3  = 0;
    public float fAngles_z_3 = 0;
    public AudioClip bgm;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        ChestBoxLockedSingleton.instance = this;
        AnimaLoop = true;
        ChestAnimator = gameObject.GetComponent<Animation>();
        LockDigitsAnimator = ChildChest.transform.GetComponent<Animation>();
        chestQuizClear = false;

        for (int i = 0; i < 3; i ++)
        {
            LockDigits[i] = 0;
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        ChestPassword[0].text = NumberPad1.ToString();
        ChestPassword[1].text = NumberPad2.ToString();
        ChestPassword[2].text = NumberPad3.ToString();

        //if (AnimaLoop == true)
        //{
        //    ChestAnimator.Play("Chest_Open");
        //    LockDigitsAnimator.Play("NumPadlockUnlock"); 
        //    AnimaLoop = false;
        //}

        if (NumberPad1 == 3 && NumberPad2 == 3 && NumberPad3 == 9)
        {
            chestQuizClear = true;
        }

        if (chestQuizClear == true && AnimaLoop == true)
        {
            ChestAnimator.Play("Chest_Open");
            this.GetComponent<SoundPlayer>().enabled = true;
            LockDigitsAnimator.Play("NumPadlockUnlock");
            AnimaLoop = false;
        }
    }      
}

// 정답: 339