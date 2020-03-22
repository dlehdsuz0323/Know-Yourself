using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBoxLocked : MonoBehaviour
{                              
    public GameObject NumberPadLockDigits1;
    public GameObject NumberPadLockDigits2;
    public GameObject NumberPadLockDigits3;

    public AudioClip bgm;
    public AudioSource audioSource;

    private int Quater = 36;
 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;

        NumberPadLockDigits1.transform.Rotate(0, 0, 0);
        NumberPadLockDigits2.transform.Rotate(0, 0, 0);
        NumberPadLockDigits3.transform.Rotate(0, 0, 0);
    }

    void Update()
    {
            //ChestBoxLockedSingleton.instance.LockDigits[0] = (ChestBoxLockedSingleton.instance.Angles_z / 36);

    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();

        if (this.name == "R_1")
        {   
            NumberPadLockDigits1.transform.Rotate(0, 0, +Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_1 = NumberPadLockDigits1.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_1 = (int)ChestBoxLockedSingleton.instance.fAngles_z_1;
            ChestBoxLockedSingleton.instance.NumberPad1 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_1 / 36);
        }

        if (this.name == "L_1")
        {
            NumberPadLockDigits1.transform.Rotate(0, 0, -Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_1 = NumberPadLockDigits1.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_1 = (int)ChestBoxLockedSingleton.instance.fAngles_z_1;
            ChestBoxLockedSingleton.instance.NumberPad1 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_1 / 36);            
        }

        if (this.name == "R_2")
        {
            NumberPadLockDigits2.transform.Rotate(0, 0, +Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_2 = NumberPadLockDigits2.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_2 = (int)ChestBoxLockedSingleton.instance.fAngles_z_2;
            ChestBoxLockedSingleton.instance.NumberPad2 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_2 / 36);
        }

        if (this.name == "L_2")
        {
            NumberPadLockDigits2.transform.Rotate(0, 0, -Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_2 = NumberPadLockDigits2.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_2 = (int)ChestBoxLockedSingleton.instance.fAngles_z_2;
            ChestBoxLockedSingleton.instance.NumberPad2 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_2 / 36);
        }

        if (this.name == "R_3")
        {
            NumberPadLockDigits3.transform.Rotate(0, 0, +Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_3 = NumberPadLockDigits3.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_3 = (int)ChestBoxLockedSingleton.instance.fAngles_z_3;
            ChestBoxLockedSingleton.instance.NumberPad3 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_3 / 36);
        }

        if (this.name == "L_3")
        {
            NumberPadLockDigits3.transform.Rotate(0, 0, -Quater);
            ChestBoxLockedSingleton.instance.fAngles_z_3 = NumberPadLockDigits3.transform.localEulerAngles.z;
            ChestBoxLockedSingleton.instance.Angles_z_3 = (int)ChestBoxLockedSingleton.instance.fAngles_z_3;
            ChestBoxLockedSingleton.instance.NumberPad3 = ((int)ChestBoxLockedSingleton.instance.fAngles_z_3 / 36);
        }
    }
}
