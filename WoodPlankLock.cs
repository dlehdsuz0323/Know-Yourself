using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlankLock : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    public GameObject WoodPlank;
    public GameObject MainDoor;
    public GameObject FloorFootStep;

    private void OnTriggerEnter(Collider other)
    {
           if(other.name == "Axe")
        {
            //if(this.gameObject.name == "WoodPlank_Lock")
            {
                this.GetComponent<SoundPlayer>().enabled = true;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //    FloorFootStep.layer = 1; // Teleport Layer int Get

                StartCoroutine(FadeScreen());


            }
        }
    }

    IEnumerator FadeScreen()
    {
        yield return new WaitForSeconds(0.3f);

        SteamVR_Fade.Start(Color.black, 5.0f);

         
    }
}
