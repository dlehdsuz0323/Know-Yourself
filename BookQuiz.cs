using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookQuiz : MonoBehaviour
{
    public bool BookQuizClear;
    public GameObject Vent;
    public GameObject[] Book = new GameObject[3];  //Element[i] > B > R > Y > G
    public GameObject[] BookCol = new GameObject[3];
    public int BookQuizClearCount;

    void Start()
    {
        BookQuizClear = false;
        BookQuizClearCount = 0;
    }

    
    void Update()
    {

        if (BookQuizClear == true)
        {
            Vent.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    private void OnTriggerStay(Collider Book)
    {
        if (this.name == "BlueBookCol")
        {
            if (Book.name == "Book_Blue")
            {
                BookQuizSingleton.instance.Book[0] = true;
            }
        }

        if(this.name == "RedBookCol")
        if (Book.name == "Book_Red")
        {
                BookQuizSingleton.instance.Book[1] = true;
        }

        if(this.name == "YellowBookCol")
        if (Book.name == "Book_Yellow")
        {
                BookQuizSingleton.instance.Book[2] = true;
        }

        if(this.name == "GreenBookCol")
        if (Book.name == "Book_Green")
        {
                BookQuizSingleton.instance.Book[3] = true;
        }
    }

    private void OnTriggerExit(Collider Book)
    {
        if (this.name == "BlueBookCol")
        {
            if (Book.name == "Book_Blue")
            {
                BookQuizSingleton.instance.Book[0] = false;
            }
        }

        if (this.name == "RedBookCol")
            if (Book.name == "Book_Red")
            {
                BookQuizSingleton.instance.Book[1] = false;
            }

        if (this.name == "YellowBookCol")
            if (Book.name == "Book_Yellow")
            {
                BookQuizSingleton.instance.Book[2] = false;
            }

        if (this.name == "GreenBookCol")
            if (Book.name == "Book_Green")
            {
                BookQuizSingleton.instance.Book[3] = false;
            }
    }
}
