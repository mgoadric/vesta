using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Dictionary<Vector3, GameObject> mines = new Dictionary<Vector3, GameObject>();

    public Dictionary<string, int> available;

    public GameObject minePrefab;

    private void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        available = new Dictionary<string, int>();
        available["mine"] = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
