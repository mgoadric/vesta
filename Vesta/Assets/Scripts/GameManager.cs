using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Dictionary<Vector3, GameObject> mines = new Dictionary<Vector3, GameObject>();

    public Dictionary<string, int> available;

    public GameObject availableButton;

    public GameObject availableContent;

    public GameObject minePrefab;

    private void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        available = new Dictionary<string, int>();
        available["mine"] = 5;
        available["habitat"] = 2;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (String s in available.Keys) {
            var child = availableContent.transform.Find(s);
            if (child == null) {
                GameObject temp = Instantiate(availableButton, availableContent.transform);
                temp.name = s;
                temp.transform.Find("Label").GetComponent<TextMeshProUGUI>().text = s + ": " + available[s];
            } else {
                child.Find("Label").GetComponent<TextMeshProUGUI>().text = s + ": " + available[s];
            }
        }
    }
}
