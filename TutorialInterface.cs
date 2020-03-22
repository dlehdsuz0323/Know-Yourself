using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialInterface : MonoBehaviour
{
    public static TutorialInterface instance = null;

    public Text TutorialMassage;
    public List<string> TutorialTextMassage;


    public bool[] TutorialSequence = new bool[10];
    public int TutorialSequenceNum = 0;
    public GameObject[] ItemLeaveBox = new GameObject[4];
    public GameObject[] ItemCreaterBox = new GameObject[4];
    public GameObject[] Person = new GameObject[2];
    public GameObject[] Door = new GameObject[2];
    public bool TutorialComplete = false;
    public GameObject[] SetActiveGameObject = new GameObject[5];
    public float NextTextTime = 10.0f;
    public bool inventoryTutorialComplete = false;
    public bool nextScene = false;
    //public bool asd = false;
    public GameObject[] BalloonSpawner = new GameObject[6];
   

    void Awake()
    {
        if(instance == null)
        instance = this;

        for (int i = 0; i < TutorialSequence.Length; i++)
        {
            TutorialSequence[i] = false;
        }

        SetActiveGameObject[0].GetComponent<TeleportVive>().enabled = false;
       // SetActiveGameObject[1].GetComponent<InventoryController>().enabled = false;
      //  SetActiveGameObject[2].GetComponent<SceneChanger>().enabled = false;
        Massage();

    }

    void Start()
    {
        TutorialSequence[0] = true;
        StartCoroutine(IntroCoroutine());
        //StartCoroutine(LoadScene());
    }

    void Update()
    {
        Debug.Log(TutorialSequenceNum);
    }


    IEnumerator IntroCoroutine()
    {
        while (true)
        {
            if (TutorialSequence[TutorialSequenceNum] == true)
            {
                if (TutorialSequenceNum < 5)
                {
                    TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                    TutorialSequenceNum++;
                    TutorialSequence[TutorialSequenceNum] = true;
                    yield return new WaitForSeconds(NextTextTime);
                    //  TutorialMassage.text = "";
                    Person[0].GetComponent<MeshRenderer>().material.color = Color.red;
                    Person[1].GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            if (TutorialSequenceNum == 5)
            {
                SetActiveGameObject[0].GetComponent<TeleportVive>().enabled = true;
                //  TutorialSequenceNum++;
                break;
            }
        }
    }

    IEnumerator TeleportComplete()
    {
            if (TutorialSequenceNum < 6)
        {
            Person[0].GetComponent<MeshRenderer>().material.color = Color.blue;
            Person[1].GetComponent<MeshRenderer>().material.color = Color.blue;

            TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
            TutorialSequenceNum++;
            yield return new WaitForSeconds(NextTextTime);
            TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();

            ItemBoxMaterialColorChanger();
            yield return new WaitForSeconds(NextTextTime);
        }
    }

    IEnumerator ItemCreaterCol()
    {
        if (inventoryTutorialComplete == false)
        {
            if (TutorialSequenceNum > 5)
                if (TutorialSequenceNum < 7)
            {
                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                yield return new WaitForSeconds(NextTextTime);

                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                yield return new WaitForSeconds(NextTextTime);
            }
        }

        if (inventoryTutorialComplete == true)
        {
            if (TutorialSequenceNum > 7)
                if (TutorialSequenceNum < 9)
            {
                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                yield return new WaitForSeconds(NextTextTime);

                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();

                for (int i = 0; i < 4; i++)
                {
                    ItemCreaterBox[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                    ItemLeaveBox[i].GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }

    IEnumerator ItemLeaveCol()
    {
        if (TutorialSequenceNum > 9)
            if (TutorialSequenceNum < 11)
        {
            TutorialSequenceNum++;
            TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
            yield return new WaitForSeconds(NextTextTime);

            TutorialSequenceNum++;
            TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
            yield return new WaitForSeconds(NextTextTime);
        }

        if (TutorialLeaveCube.instance.LeaveBoxComplete == true) 
        {
            if (TutorialSequenceNum > 11)
                if (TutorialSequenceNum < 13)
            {
                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                yield return new WaitForSeconds(NextTextTime);

                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                Door[0].GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
                Door[1].GetComponent<MeshRenderer>().material.color = Color.red;
                yield return new WaitForSeconds(NextTextTime);
            }
        }
    }

    IEnumerator DoorOpen()
    {
        if (TutorialSequenceNum > 13)
            if (TutorialSequenceNum < 15)
        {
            TutorialSequenceNum++;
            TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
            yield return new WaitForSeconds(NextTextTime);
        }

        if (TutorialSequenceNum < 17)
        {
            if (TutorialComplete == true)
            {
                Door[0].GetComponent<SkinnedMeshRenderer>().material.color = Color.blue;
                Door[1].GetComponent<MeshRenderer>().material.color = Color.blue;

                TutorialSequenceNum++;
                TutorialMassage.text = TutorialTextMassage[TutorialSequenceNum].ToString();
                nextScene = true;
                //SetActiveGameObject[2].GetComponent<SceneChanger>().enabled = true;
                SetActiveGameObject[3].SetActive(false);

                //for(int i = 0; i < 6; i++)
                //{
                //    BalloonSpawner[i].SetActive(true);
                //}

                yield return new WaitForSeconds(NextTextTime);

            }
        }
    }

    IEnumerator SceneChange()
    {
        SceneChanger.instance.num1 = 2;
        yield return new WaitForSeconds(NextTextTime);
        SceneChanger.instance.num1 = 1;
    }

    //IEnumerator LoadScene()
    //{
    //    yield return null;
    //    AsyncOperation async = SceneManager.LoadSceneAsync("InputTestScene");
    //        async.allowSceneActivation = false;
    //    while(!async.isDone)
    //    {
    //        if (num1 == 1) async.allowSceneActivation = true;
    //        yield return null;
    //        Debug.Log(async.progress);            
    //    }
    //}

    void Massage()
    {
        TutorialTextMassage.Add("안녕하십니까 NewBies의 게임에 오신것을 환영합니다."); //0
        TutorialTextMassage.Add("본 게임을 진행하기전에 튜토리얼을 먼저 실행하겠습니다"); //1
        TutorialTextMassage.Add("앞에 보이는 팻말의 튜토리얼을 따라 진행해주시기 바랍니다."); //2
        TutorialTextMassage.Add("그럼 시작하겠습니다."); //3

        TutorialTextMassage.Add("우선 이동을 먼저 해보겠습니다. 전방에 보이는 사람에게 다가가세요");  //4
        TutorialTextMassage.Add("잘하셨습니다."); //5
        TutorialTextMassage.Add("다음은 빨간색 박스 앞으로 이동해보겠습니다."); //6

        TutorialTextMassage.Add("왼쪽 컨트롤러를 아이템에 가져다대고 트리거를 당기면 인벤토리에 들어가게됩니다."); //7
        TutorialTextMassage.Add("모든 아이템을 인벤토리에 넣어주세요."); //8
        TutorialTextMassage.Add("잘하셨습니다."); //9
        TutorialTextMassage.Add("다음 빨간색 박스 앞으로 이동해주시기 바랍니다."); //10

        TutorialTextMassage.Add("왼쪽 컨트롤러의 좌우 버튼으로 아이템을 선택하고 밑 버튼을 이용하여 아이템을 떨어뜨립니다"); //11
        TutorialTextMassage.Add("모든 아이템을 큐브에 하나씩 올려보세요."); //12

        TutorialTextMassage.Add("잘하셨습니다."); //13
        TutorialTextMassage.Add("열쇠를 다시 인벤토리에 넣고 문 앞으로 가십시오."); //14

        TutorialTextMassage.Add("열쇠를 문고리에 가져다가 대십시오."); //15
        TutorialTextMassage.Add("수고하셨습니다. 모든 튜토리얼이 끝났습니다."); //16
        TutorialTextMassage.Add("다음 장소로 이동하십시오."); //17

    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Sphere002")
        {
            StartCoroutine(TeleportComplete());
        }

        if (other.name == "ItemCreaterCollider")
        {
            SetActiveGameObject[1].GetComponent<InventoryController>().enabled = true;
            StartCoroutine(ItemCreaterCol());
        }

        if (other.name == "ItemLeaveCollider")
        {
             StartCoroutine(ItemLeaveCol());
        }

        if (other.name == "Object003 (1)")
        {
            StartCoroutine(DoorOpen());
        }

        if (other.name == "SceneChange")
        {
            StartCoroutine(SceneChange());
        }
    }

    
    void ItemBoxMaterialColorChanger()

    {
        for(int i = 0; i < 4; i ++)
        {
            ItemCreaterBox[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
