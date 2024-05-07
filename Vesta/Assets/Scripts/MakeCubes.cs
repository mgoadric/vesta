using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCubes : MonoBehaviour
{

    public int maxDistance;

    public int centerRange;

    public GameObject cubePrefab;

    public List<GameObject> asteroid = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {   
        NewAsteroid();
        //StartCoroutine(ResetPlanet());
    }

    IEnumerator ResetPlanet() {
        while(true) {
            yield return new WaitForSeconds(1);
            DeleteAsteroid();
            NewAsteroid();
        }
    }

    void NewAsteroid() {
        Vector3 xCent = new Vector3(centerRange / 2.0f - Random.Range(0, centerRange), 0, 0); 
        Vector3 yCent = new Vector3(0, centerRange / 2.0f - Random.Range(0, centerRange), 0); 
        Vector3 zCent = new Vector3(0, 0, centerRange / 2.0f - Random.Range(0, centerRange)); 
        for (int i = -10; i < 10; i++) {
            for (int j = -10; j < 10; j++) {
                for (int k = -10; k < 10; k++) {
                    Vector3 location = new Vector3(i, j, k);
                    if ((location - xCent).magnitude <= maxDistance + Random.Range(0, 2) ||
                        (location - yCent).magnitude <= maxDistance + Random.Range(0, 2) ||
                        (location - zCent).magnitude <= maxDistance + Random.Range(0, 2)) {
                        asteroid.Add(Instantiate(cubePrefab, location, Quaternion.identity));
                    }
                }
            }
        } 
    }

    void DeleteAsteroid() {
        foreach (GameObject go in asteroid) {
            Destroy(go);
        }
        asteroid.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
