using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
  public enum EnemyState
  {
    GoToBase,
    ChasePlayer,
    AttackBase,
    AttackPlayer,
  }

    public EnemyState currentState;

    void Update()
    {
        if(currentState == EnemyState.GoToBase)
        {
            print("GoToBase");
        }
        else if(currentState == EnemyState.ChasePlayer)
        {
            print("ChasePlayer");
        }
        else if(currentState == EnemyState.AttackBase)
        {
            print("AttackBase");
        }
        else
        {
            print("AttackPlayer");
        }
    }
}
