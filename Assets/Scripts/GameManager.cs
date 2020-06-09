using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake(){
        instance = this;
    }

    public event Action onGameEnded;

    public void EndGame(){
        gameEnded();
    }

    void gameEnded(){
        Debug.Log("Game ended event triggered!");
        if(onGameEnded != null){
            onGameEnded();
        }
    }
}
