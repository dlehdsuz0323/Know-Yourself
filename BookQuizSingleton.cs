using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookQuizSingleton : MonoBehaviour
{
    public static BookQuizSingleton instance;

    [Header("BookQuiz")]
    public AudioClip bgm;
    public AudioSource audioSource;
    public bool[] Book = new bool[4];  //Element[i] > B > R > Y > G
    public int BookQuizClearCount;
    public bool BookQuizClear;
    public GameObject Vent;
    public bool soundplay = false;

    public void Awake()
    {
        instance = FindObjectOfType(typeof(BookQuizSingleton)) as BookQuizSingleton;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
    }


    void Start()
    {
        BookQuizInit();
    }


    void Update()
    {
        BookQuiz();
    }


    void BookQuizInit()
    {
        BookQuizClearCount = 0;
        BookQuizClear = false;

        for (int i = 0; i < Book.Length; i++)
        {
            Book[i] = false;
        }
    }

    void BookQuiz()
    {
        if (BookQuizClear == false)
        {
            BookQuizClearCount = 0;
            for (int i = 0; i < Book.Length; i++)
            {
                if (Book[i] == true)
                {
                    BookQuizClearCount++;
                }

                if (BookQuizClearCount == 4)
                {
                    if (soundplay == false)
                    {
                        BookQuizClear = true;
                        soundplay = true;
                    }
                 //   audioSource.Play();
                }
            }
        }


        if (BookQuizClear == true)
        {
            Vent.GetComponent<SoundPlayer>().enabled = true;
            Vent.GetComponent<Rigidbody>().useGravity = true;
            Vent.GetComponent<Rigidbody>().isKinematic = false;
          //  playAudio.Play();
            // 장재완 추가  --- 문앞에 있는 상자 밀쳐내면서 열리게
            //Vent.GetComponent<Rigidbody>().AddForce(0, 0, 10.0f);     
            // 장재완 추가
        }
      //  Debug.Log(BookQuizClearCount);
    }
}
