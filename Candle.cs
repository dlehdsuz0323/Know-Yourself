using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject candleParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Match")
        {   // 충돌한 오브젝트가 MatchObject script를 가지지 않으면
            if (!collision.transform.GetComponent<MatchObject>())
                return;

            // 불켜진 성냥일 때
            else if (collision.transform.GetComponent<MatchObject>().isFire)
                candleParticle.SetActive(true);
        }
    }
}
