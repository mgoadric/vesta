using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSurface : MonoBehaviour
{

    new public Renderer renderer;

    public GameObject mine;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.grey;
        
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
        Instantiate(mine, transform);
    }

    void OnMouseExit() {
        renderer.material.color = Color.gray;
    }
}
