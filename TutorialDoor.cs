using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    public static TutorialDoor instance = null;

    Animation DoorAnimator;
    public bool AnimaLoop;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DoorAnimator = gameObject.GetComponent<Animation>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key_Library")
        {
            if (this.gameObject.name == "Door")
            TutorialInterface.instance.TutorialComplete = true;
            TutorialInterface.instance.Door[0].GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
            TutorialInterface.instance.Door[1].GetComponent<MeshRenderer>().material.color = Color.blue;
                DoorAnimator.Play();
            AnimaLoop = true;
        }
    }
}
