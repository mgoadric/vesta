using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateCamera : MonoBehaviour
{

    public Transform target;

    public int speed;

    public bool zoomed = false;

    public Vector3 zoomGoal;

    public int delta = 10;


    // Start is called before the first frame update
    void Start()
    {
        zoomGoal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cpos = transform.position;
        if ((cpos - zoomGoal).sqrMagnitude > 0.01) {
            cpos = Vector3.Lerp(cpos, zoomGoal, 0.05f);
            transform.position = cpos;
        } else {
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) {
                transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Horizontal") * -speed * Time.deltaTime);
            }
            if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) {
                transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Q)) {
                transform.RotateAround(target.transform.position, transform.forward, speed * Time.deltaTime);
            } else if (Input.GetKey(KeyCode.E)) {
                transform.RotateAround(target.transform.position, transform.forward, -speed * Time.deltaTime);
            }
            zoomGoal = transform.position;
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (zoomed) {
                    zoomGoal = transform.position + transform.forward * -delta;
                    zoomed = false;
                } else {
                    zoomGoal = transform.position + transform.forward * delta;
                    zoomed = true;
                }
            }
        }
    }
}
