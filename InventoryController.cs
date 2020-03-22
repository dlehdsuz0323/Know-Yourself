using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



public class InventoryController : MonoBehaviour
{
    private enum ItemCode
    {
        Empty,
        Match,
        Candle,
        RedBook,
        YellowBook,
        Key,
        GreenBook,
        BlueBook,
        Axe
    }
    private SteamVR_TrackedObject trackedObj;
    public GameObject[] items;
    public string itemName;
    private bool isInsertTimer = false;
    private int selectedIndex = 0;
    private int inventoryMax = 8;
    private int inventoryItemNum = 0;


    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        items    = new GameObject[inventoryMax];
        items[0] = transform.GetChild(0).gameObject;
    }


    void FixedUpdate()
    {   

        if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (isInsertTimer)
                    return;
            StartCoroutine("CheckInsertTimer");
            UserInterface.GetInstance().ViewTutorialLeft();
        }
        if(GameManager.GetInstance().CheckGameStatePause())
            return;


        // 템선택창 혹시 오류 뜨면 주석 부분 전부 살리고 MoveSelect 2개 주석처리하면됨
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (isInsertTimer)
                return;
            StartCoroutine("CheckInsertTimer");
            Vector2 touchPadAxis = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            if (touchPadAxis.y > 0.7f)           // 위
                DropItem();


            if (touchPadAxis.y < -0.7f)          // 아래                
                DropItem();


            if (touchPadAxis.x > 0.7f)           // 우
            {
                Debug.Log("우클릭");
                MoveSelectRight();
                //selectedIndex++;
            }

            else if (touchPadAxis.x < -0.7f)          // 좌
            {
                Debug.Log("좌클릭");
                MoveSelectLeft();
                //selectedIndex--;
            }
            
            //if (selectedIndex < 0)
            //    selectedIndex = inventoryMax - 1;
            //
            //else if (selectedIndex > inventoryMax - 1)
            //    selectedIndex = 0;
            //
            UpdateSelectedItem();
            UserInterface.GetInstance().UpdateInventory(selectedIndex);
        }


        // 트리거 물체 충돌 on / off
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            GetComponent<BoxCollider>().isTrigger = false;
        

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            GetComponent<BoxCollider>().isTrigger = true;

        if(TutorialInterface.instance!= null)
        if (TutorialInterface.instance.inventoryTutorialComplete == false)
        {
            inventoryItemNum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (items[i] != null)
                {
                    inventoryItemNum++;

                    if (i == 4)
                    {
                        TutorialInterface.instance.inventoryTutorialComplete = true;
                    }
                }
            }
        }
    }


    public void DropItem()
    {
        if (selectedIndex == 0 || items[selectedIndex] == null)
            return;
        items[selectedIndex].SetActive(true);
        items[selectedIndex].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        items[selectedIndex].transform.parent = null;
        items[selectedIndex] = null;
        UserInterface.GetInstance().DropItem(selectedIndex);
        UserInterface.GetInstance().UpdateInventory(selectedIndex);
        selectedIndex = 0;
    }


    private void MoveSelectLeft()
    {
        int num = selectedIndex;
        for (int i = 0; i < inventoryMax; i++)
        {
            num--;
            if (num < 0)
            {
                num = inventoryMax - 1;
            }

          //  if (items[num])
            {
                selectedIndex = num;
                UserInterface.GetInstance().UpdateInventory(selectedIndex);
                Debug.Log(num);
                return;
            }
        }
    }


    private void MoveSelectRight()
    {
        int num = selectedIndex;
        for (int i = 0; i < inventoryMax; i++)
        {
            num++;
            if (num > inventoryMax - 1)
            {
                num = 0;
            }

        //    if (items[num])
            {
                selectedIndex = num;
                UserInterface.GetInstance().UpdateInventory(selectedIndex);
                return;
            }
        }
    }


    private void UpdateSelectedItem()
    {   
        for (int i = 0; i < inventoryMax; i++)
        {
            if (items[i])
                items[i].SetActive(false);
        }

        
        if (selectedIndex == 0)
        {
            GetComponent<BoxCollider>().enabled = true;
            items[0].SetActive(true);
        }
        else
        {   
          //  GetComponent<BoxCollider>().enabled = false;
            if (items[selectedIndex])
                items[selectedIndex].SetActive(true);
        }

    }


    IEnumerator CheckInsertTimer()
    {
        isInsertTimer = true;
        yield return new WaitForSeconds(0.1f);
        isInsertTimer = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Item")
            return;


        for (int i = 1; i < inventoryMax; i++)
        {
            if (items[i] == collision.gameObject)
                return;
        }


        for (int i = 1; i < inventoryMax; i++)           // 0번 인덱스는 항상 비워놔야 한다.
        {
            if (!items[i])
            {
                int itemCode = 0;
                items[i] = collision.gameObject;
                switch(collision.gameObject.name)
                {
                    case "Match":
                        itemCode = 1;
                        itemName = "Match";
                        break;

                    case "Candle":
                        itemCode = 2;
                        itemName = "Candle";
                        break;

                    case "Book_Red":
                        itemCode = 3;
                        itemName = "Book_Red";
                        break;

                    case "Book_Yellow":
                        itemCode = 4;
                        itemName = "Book_Yellow";
                        break;

                    case "Key_Library":
                        itemCode = 5;
                        itemName = "Key_Library";
                        break;

                    case "Book_Green":
                        itemCode = 6;
                        itemName = "Book_Green";
                        break;

                    case "Book_Blue":
                        itemCode = 7;
                        itemName = "Book_Blue";
                        break;

                    case "Axe":                     // 도끼 추가 예정 이름도 예정
                        itemCode = 8;
                        itemName = "Axe";
                        break;

                    case "WomanToiletKey":
                        itemCode = 9;
                        itemName = "WomanToiletKey";
                        break;

                    default:
                        itemCode = 0;       // Empty
                        itemName = "Controller";
                        break;
                }
                UserInterface.GetInstance().GetItem(i, itemCode, itemName);
                break;
            }
        }
        collision.transform.position = transform.position;
        collision.transform.SetParent(this.transform);
        collision.transform.gameObject.SetActive(false);
        //collision.transform.position = Vector3.zero;
        collision.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
