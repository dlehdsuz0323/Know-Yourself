using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLeaveCube : MonoBehaviour
{
    public static TutorialLeaveCube instance = null;

    public GameObject[] ItemLeaveBox = new GameObject[4];
    public bool LeaveBoxComplete = false;
    public int LeaveBoxNum = 0;
    public bool BlueSet;
    public Color BlueColor;
    public Color RedColor;

    public Collision col;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        RedColor = Color.red;
        BlueColor = Color.blue;
    }

    void Start()
    {
      
       // this.GetComponent<MeshRenderer>().material.color = Color.red;

     //  if( this.GetComponent<MeshRenderer>().material.color.Equals(asd))
        {
           // Debug.Log("color Equals");
        }
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if(ItemLeaveBox[i].GetComponent<MeshRenderer>().material.color.Equals(BlueColor))
            {
                LeaveBoxNum++;
            }
        }

        if (LeaveBoxNum == 4)
        {
            LeaveBoxComplete = true;
        }
        else if(LeaveBoxNum != 4)
        {
            LeaveBoxNum = 0;
        }

    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Item")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            this.BlueSet = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Item")
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
            this.BlueSet = true;          
        }
        else if (collision.collider == null)
        {
            //this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
