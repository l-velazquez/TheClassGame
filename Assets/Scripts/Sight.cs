using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public LayerMask objectsLayer;

    public float distance;
    public float angle;
    public Collider detectedObject;

    // Update is called once per frame
    void Update()
    {
        // todo lo que este dentro de esfera metelo a una lista de collider.
        Collider[] colliders = Physics.OverlapSphere(transform.position,
                                                     distance, objectsLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            // el colider especifico.
            Collider collider = colliders[i];
            //determinar angulo de object, from where ya are to direction of obstcle.
            Vector3 directionToController = 
            Vector3.Normalize(collider.bounds.center - transform.position);
            //angulo hacia collider.
            float angleToCollider = 
            Vector3.Angle(transform.forward, directionToController);
            //verifies angle to collider and angle.
            if (angleToCollider < angle)
            {
                //verifies if an object is detected.
                if (Physics.Linecast(transform.position,
                                     collider.bounds.center, obstacleLayer))
                {
                    detectedObject = collider;
                    break;
                }
            }

        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector3 rightDirection = Quaternion.Euler(0,angle,0)*transform.forward;
    }
}


