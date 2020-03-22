using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCube : MonoBehaviour
{
    public static LeaveCube instance = null;


    public bool[] CubeSetBlue = new bool[4];
    public int asd = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
            asd = 0;
        for(int i = 0; i < 4; i++)
        {
           if ( TutorialLeaveCube.instance.BlueSet == true)
            {
                asd++;
                Debug.Log(asd);
            }
        }
    }
}
