using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public Camera Camera;
    public Transform target;

    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Camera.transform.RotateAround(target.transform.position, Camera.transform.up, -speed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) {
            Camera.transform.RotateAround(target.transform.position, Camera.transform.up, speed * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.UpArrow)) {
            Camera.transform.RotateAround(target.transform.position, Camera.transform.right, speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            Camera.transform.RotateAround(target.transform.position, Camera.transform.right, -speed * Time.deltaTime);
        }


    }
}
