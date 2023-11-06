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

    public Sight sightSensor;
    public float baseAttackDistance;
    public float playerAttackDistance;
    public Transform baseTransform;


    void Update()
    {
        if(currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if(currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else if(currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        else
        {
            AttackPlayer();
        }
    }

    void GoToBase()
    {
        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position,baseTransform.position);
        if(distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void ChasePlayer()
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
    float distanceToPlayer = Vector3.Distance(transform.position,
                                            sightSensor.detectedObject.transform.position);
        if(distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackBase()
    {
        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToPlayer = Vector3.Distance(transform.position,sightSensor.transform.position);

        if (distanceToPlayer > playerAttackDistance * 1.1)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void AttackPlayer()
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
        

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
    }

}

