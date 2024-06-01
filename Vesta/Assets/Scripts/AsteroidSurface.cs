using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

public class AsteroidSurface : MonoBehaviour
{

    new Renderer renderer;

    Vector3Int constructPosPotential;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.grey;
        Vector3 startPosition = transform.position;
        Vector3 startForward = transform.forward;
        Vector3 tempPosition = startPosition + (startForward * -0.5f);
        constructPosPotential = new Vector3Int(Mathf.RoundToInt(tempPosition.x), 
                                            Mathf.RoundToInt(tempPosition.y), 
                                            Mathf.RoundToInt(tempPosition.z));
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
        GameManager.Instance.AddBuilding(transform, constructPosPotential);
    }

    void OnMouseExit() {
        renderer.material.color = Color.gray;
    }
}
