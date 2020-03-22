using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance = null;

    public int num1 = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    void Update()
    {
        if (num1 == 2)
        {
        //    SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync("InputTestScene");
        AsyncOperation async2 = SceneManager.LoadSceneAsync("SampleScene");
        async.allowSceneActivation = false;
        async2.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (num1 == 1)
                async.allowSceneActivation = true;
            if (num1 == 2)
                async2.allowSceneActivation = true;
            yield return null;
            Debug.Log(async.progress);
        }
    }
}
