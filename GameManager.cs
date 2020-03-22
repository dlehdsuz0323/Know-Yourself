using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameManager GetInstance()
    {
        return instance;
    }
    private GameState gameState;


    public enum GameState
    {
        play,
        pause
    }
    

    private void Awake()
    {
        instance = FindObjectOfType(typeof(GameManager)) as GameManager;
        DontDestroyOnLoad(this);

        gameState = GameState.pause;
    }


    public bool CheckGameStatePause()
    {
        if (gameState == GameState.pause)
            return true;
        return false;
    }


    public void SetGamePause()
    {
        gameState = GameState.pause;
    }


    public void SetGamePlay()
    {
        gameState = GameState.play;
    }
}
