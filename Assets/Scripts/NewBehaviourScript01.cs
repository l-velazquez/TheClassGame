using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript01 : MonoBehaviour
{
    // Start is called before the first frame update
    //public float speed;
    [SerializeField] 
    private float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.05f);
    }
}
