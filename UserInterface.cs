using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UserInterface : MonoBehaviour
{
    private int itemMax = 9;                // 총아이템 갯수


    private static UserInterface instance = null;
    public static UserInterface GetInstance()
    {
        return instance;
    }


    private List<Image> items          = new List<Image>();
    private List<Sprite> images        = new List<Sprite>();
    private GameObject selectedItem;
    public Text[] ItemName = new Text[1];

    // 인트로
    public GameObject logo;
    public GameObject title;
    public GameObject tutorial_Left;
    public GameObject tutorial_Right;
    private bool isLeftView;
    private bool isRightView;
    public float setActiveTime = 11.0f;

    private void Awake()
    {
        instance = FindObjectOfType(typeof(UserInterface)) as UserInterface;
       // DontDestroyOnLoad(this);

        // Empty와 Selected는 직접 불러옴
        string imageName = "item";
        images.Add(Resources.Load<Sprite>("Empty"));
        selectedItem = transform.GetChild(8).gameObject;
        selectedItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Selected");


        for(int i = 0; i< itemMax; i++)
            images.Add(Resources.Load<Sprite>(imageName+(i+1)));      // 0번은 Empty라서 +1


        for (int i= 0; i < 8; i++)                                   // 템칸 8칸이라서
        {
            items.Add(transform.GetChild(i).gameObject.GetComponent<Image>());
            items[i].sprite = images[0];
            // 인트로 씬을 위해 모든 UI 끔
            items[i].enabled = false;
            selectedItem.SetActive(false);
        }


        tutorial_Left.SetActive(false);
        tutorial_Right.SetActive(false);
        logo.SetActive(true);
        title.SetActive(true);
        isLeftView  = true;
        isRightView = true;
        StartCoroutine(IntroTimer());
    }


    // 조작부
    public void UpdateInventory(int index)
    {   // Selected 이동
        selectedItem.GetComponent<RectTransform>().position = items[index].transform.position;
    }


    public void SetActivateUI()
    {
        for (int i = 0; i < 8; i++)
        {
            items[i].enabled = true;
            selectedItem.SetActive(true);
        }
    }


    public void GetItem(int index, int itemNum, string itemName)    
    {
        items[index].sprite = images[itemNum];
        ItemName[0].text = itemName.ToString();
        StartCoroutine(itemStringTextVisible());
    }


    public void DropItem(int index)                   
    {    // 이미지 삭제
        items[index].sprite = images[0];
        UpdateInventory(index);
    }


    public int GetItemMax()
    {
        return itemMax;
    }


    public void ViewTutorialLeft()
    {
        if (isLeftView)
        {
            isLeftView = false;
            tutorial_Left.SetActive(false);
            Debug.Log("끄기");
        }
        else
        {
            isLeftView = true;
            tutorial_Left.SetActive(true);
            Debug.Log("켜기");
        }

        if (isRightView)
        {
            isRightView = false;
            tutorial_Right.SetActive(false);
            Debug.Log("끄기");
        }
        else
        {
            isRightView = true;
            tutorial_Right.SetActive(true);
            Debug.Log("켜기");
        }
    }


    public void ViewTutorialRight()
    {
        if (isRightView)
        {
            isRightView = false;
            tutorial_Right.SetActive(false);
            Debug.Log("끄기");
        }
        else
        {
            isRightView = true;
            tutorial_Right.SetActive(true);
            Debug.Log("켜기");
        }
    }


    IEnumerator IntroTimer()   
    {
        logo.SetActive(false);
        title.SetActive(false);
        yield return new WaitForSeconds(setActiveTime);
      //  tutorial_Left.SetActive(true);
      //  tutorial_Right.SetActive(true);
        SetActivateUI();
        GameManager.GetInstance().SetGamePlay();
    }

    IEnumerator itemStringTextVisible()
    {
        yield return new WaitForSeconds(2.0f);
        ItemName[0].text = "";
    }
}
