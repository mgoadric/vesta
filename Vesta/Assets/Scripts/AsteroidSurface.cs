using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AsteroidSurface : MonoBehaviour
{

    new public Renderer renderer;

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
        if (GameManager.Instance.available["mine"] > 0) {
            Vector3 minepos = transform.position + (transform.forward * -0.5f);
            Vector3Int mpi = new Vector3Int(Mathf.RoundToInt(minepos.x), 
                                            Mathf.RoundToInt(minepos.y), 
                                            Mathf.RoundToInt(minepos.z));
            Debug.Log("tp: " + transform.position + ", forward: " + transform.forward + " minepos: " + mpi);
            if (!GameManager.Instance.mines.ContainsKey(mpi)) {
                GameManager.Instance.mines.Add(mpi, Instantiate(GameManager.Instance.minePrefab, transform));
            }
            GameManager.Instance.available["mine"]--;
        }
    }

    void OnMouseExit() {
        renderer.material.color = Color.gray;
    }
}
