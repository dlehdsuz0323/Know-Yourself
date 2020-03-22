using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    Animation DoorAnimator;
    public GameObject WomanToiletKey;
    public AudioClip bgm;
    public AudioSource audioSource;
    public bool AnimaLoop;

    void Start()
    {
        AnimaLoop = false;
        DoorAnimator = gameObject.GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (AnimaLoop == false)
        {

            if (this.gameObject.name == "ToiletCabin_openable_KeyDrop")
            {
                WomanToiletKey.GetComponent<Rigidbody>().useGravity = true;
                WomanToiletKey.GetComponent<SoundPlayer>().enabled = true;
                audioSource.Play();
                DoorAnimator.Play();
                WomanToiletKey.SetActive(true);
                AnimaLoop = true;
            }


            else if (collision.name == "WomanToiletKey")
            {
                if (this.gameObject.name == "ToiletCabin_openable_WomanToiletDoor")
                    audioSource.Play();
                DoorAnimator.Play();
                AnimaLoop = true;
            }

            else if (collision.name == "Key_Library")
            {
                if (this.gameObject.name == "Library_Door_Lock")
                audioSource.Play();
                    DoorAnimator.Play();
                AnimaLoop = true;
            }

            else if (this.gameObject.name == "ManToiletDoorNarrowSolid")
            {
                audioSource.Play();
                DoorAnimator.Play();
                AnimaLoop = true;
            }

            else if (this.gameObject.name == "WomanToiletDoorNarrowSolid")
            {
                audioSource.Play();
                DoorAnimator.Play();
                AnimaLoop = true;
            }

            //else if ()
            //{                
            //    if (this.gameObject.name == "DoorMain")
            //        DoorAnimator.Play();
            //    AnimaLoop = true;
            //    // GameManager -> End
            //}
        }
    }
}
