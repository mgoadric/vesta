using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCubes : MonoBehaviour
{

    public GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = -7; i < 7; i++) {
        for (int j = -7; j < 7; j++) {
            for (int k = -7; k < 7; k++) {
                Vector3 location = new Vector3(i, j, k);
                if (location.magnitude <= 5 + Random.Range(0, 2) ||
                (location - new Vector3(0, 2, 0)).magnitude <= 5 + Random.Range(0, 2)) {
        Instantiate(cubePrefab, location, Quaternion.identity);
        }
            }
        }
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
