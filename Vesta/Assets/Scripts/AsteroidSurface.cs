using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

public class AsteroidSurface : MonoBehaviour
{

    new Renderer renderer;

    public Vector3 startPosition;
    public Vector3 startForward;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.grey;
        startPosition = transform.position;
        startForward = transform.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        renderer.material.color = Color.red;
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseDown() {
        GameManager.Instance.AddBuilding(transform, startPosition, startForward);
    }

    void OnMouseExit() {
        renderer.material.color = Color.gray;
    }
}
