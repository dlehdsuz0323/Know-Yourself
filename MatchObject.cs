using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public float countTimer = 0.0f;
    public float colTimer = 1.0f;
    public bool isFire = false;
    public bool isBoxCol = false;
    public bool isSphereCol = false;
    public GameObject matchLight;


    private void FixedUpdate()
    {   
        if (isBoxCol || isSphereCol)
            countTimer += Time.deltaTime;

        if (isBoxCol && isSphereCol)
        {
            if (countTimer <= colTimer)
                ActivateMatch();
            else
                ResetMatch();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MatchPack_Out")
        {
            if (other is BoxCollider)
                isBoxCol = true;

            if (other is SphereCollider)
                isSphereCol = true;
        }
    }


    private void ActivateMatch()
    {
        isFire = true;
        isBoxCol = false;
        isSphereCol = false;
        matchLight.SetActive(true);
        StartCoroutine("CheckFireLife");
        SoundManager.instance.PlayAudio("Match");
    }


    private void ResetMatch()
    {
        countTimer = 0.0f;
        isBoxCol = false;
        isSphereCol = false;
    }


    // 성냥이 켜진뒤 몇초뒤에 꺼지게 할지 결정
    IEnumerator CheckFireLife()
    {
        yield return new WaitForSeconds(5.0f);  // 시간
        matchLight.SetActive(false);
        isFire = false;
        isBoxCol = false;
        isSphereCol = false;
    }
}
