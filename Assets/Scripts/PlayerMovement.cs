using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject prefab;
    public GameObject shootPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }   
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        { transform.Translate(0,0,speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        { transform.Translate(0,0,-speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        { transform.Translate(-speed * Time.deltaTime,0,0); }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        { transform.Translate(speed * Time.deltaTime,0,0); }
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotationSpeed * mouseX, 0);
    }
}
