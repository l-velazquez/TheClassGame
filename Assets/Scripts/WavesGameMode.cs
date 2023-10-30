using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{   
    [SerializeField] public Life playerLife;
    [SerializeField] public Life playerBaseLife;
    void Start(){    
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinConditions);
        WaveManager.instance.onChanged.AddListener(CheckWinConditions);
    }
    
    private void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    
    private void CheckWinConditions()
    {
        if(EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count <= 0){
            //print("You win!");
            SceneManager.LoadScene("WinScreen");
        }
        if(playerLife.amount <= 0){
            //print("You lose :(");
            SceneManager.LoadScene("LoseScreen");
        }

    }
    
}