using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzle : MonoBehaviour
{  
    public int indexCount;              // 정답 순서를 확인 하기 위해
    public int[] answer;                // 정해진 정답
    public int[] tryAnswer;             // 유저가 시도할 정답
    public bool isComplete;             // 퍼즐을 완료했는가 ?         <---- 해당 bool값을 통해 퍼즐 완료를 측정할 예정
    public bool colRed;                 // 해당 색을 이미 충돌햇는가 ?
    public bool colBlue;                // 해당 색을 이미 충돌햇는가 ?
    public bool colGreen;               // 해당 색을 이미 충돌햇는가 ?
    public bool colYellow;              // 해당 색을 이미 충돌햇는가 ?


    private void Awake()
    {
        isComplete = false;
        InitPuzzle();
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Book_Red":
                tryAnswer[indexCount] = 1;
                indexCount++;
                break;

            case "Book_Blue":
                tryAnswer[indexCount] = 2;
                indexCount++;
                break;

            case "Book_Green":
                tryAnswer[indexCount] = 3;
                indexCount++;
                break;

            case "Book_Yellow":
                tryAnswer[indexCount] = 4;
                indexCount++;
                break;

            default:
                break;
        }


        if (indexCount >= 4)            // 정답 4자리수가 모두 입력되면 
        {
            if (answer == tryAnswer)    // 퍼즐 정답
                isComplete = true;

            else                        // 퍼즐 오답
                InitPuzzle();
        }
    }


    private void InitPuzzle()
    {   // 파빨노초 순이라 2143
        answer[0] = 2;
        answer[1] = 1;
        answer[2] = 4;
        answer[3] = 3;


        tryAnswer[0] = 0;
        tryAnswer[1] = 0;
        tryAnswer[2] = 0;
        tryAnswer[3] = 0;

        indexCount = 0;
        colRed     = false;
        colBlue    = false;
        colGreen   = false;
        colYellow  = false;
    }
}
