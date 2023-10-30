using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public List<WaveSpawner> waves;
    public UnityEvent onChanged;

    // Simpleton design pattern.
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogError("Duplicated wave Manager",gameObject);
        }
    }

    public void AddWave(WaveSpawner wave){
        waves.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave){
        waves.Remove(wave);
        onChanged.Invoke();
    }
}
