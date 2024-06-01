using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Construct {
    public string name;
    public GameObject prefab;
}

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public GameObject asteroidPrefab;

    public Dictionary<Vector3, GameObject> buildings = new();

    public List<Construct> constructs = new();

    public Dictionary<string, GameObject> constructDict = new();

    public Dictionary<string, int> available;

    public GameObject availableButton;

    public GameObject availableContent;

    public string selected;

    private void Awake() {
        _instance = this;
        foreach (Construct construct in constructs) {
            constructDict[construct.name] = construct.prefab;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(asteroidPrefab);
        available = new Dictionary<string, int>
        {
            ["mine"] = 3,
            ["storage"] = 1,
            ["habitat"] = 1
        };
    }

    void SetSelected(String which) {
            selected = which;
            print(which + " Selected");
    }

    public GameObject SelectedConstruct() {
        if (selected != null && available.ContainsKey(selected) && available[selected] > 0) {
            return constructDict[selected];
        } else {
            return null;
        }
    }

    public void AddBuilding(Transform surface, Vector3Int constructPosPotential) {
        GameObject construct = SelectedConstruct();
        if (construct != null) {
            if (!buildings.ContainsKey(constructPosPotential)) {
                buildings.Add(constructPosPotential, Instantiate(construct, surface));
                available[selected]--;
                if (available[selected] == 0) {
                    selected = "none";
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (String s in available.Keys) {
            var child = availableContent.transform.Find(s);
            if (child == null) {
                GameObject temp = Instantiate(availableButton, availableContent.transform);
                temp.name = s;
                child = temp.transform;
                Button b = child.gameObject.GetComponent<Button>();
                b.onClick.AddListener(delegate { SetSelected(child.gameObject.name); });
            } 
            child.Find("Label").GetComponent<TextMeshProUGUI>().text = s + ": " + available[s];
            if (s == selected) {
                child.GetComponent<Image>().color = Color.red;
            } else {
                child.GetComponent <Image>().color = Color.white;
            }
            if (available[s] > 0) {
                child.GetComponent<Button>().interactable = true;
            } else {
                child.GetComponent<Button>().interactable = false;
            }
         }
    }
}
