using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public GameObject asteroidPrefab;

    public GameObject constructGUI;

    private ConstructManager constructManager;

    public Dictionary<Vector3, GameObject> buildings = new();


    private void Awake() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(asteroidPrefab);
        constructManager = constructGUI.GetComponent<ConstructManager>();
    }

    public void AddBuilding(Transform transform, Vector3Int constructPosPotential) {
        constructManager.AddBuilding(transform, constructPosPotential);
    }
}
