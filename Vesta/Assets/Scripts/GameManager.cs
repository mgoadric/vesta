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

    public Dictionary<Vector3, GameObject> buildings = new Dictionary<Vector3, GameObject>();

    public List<Construct> constructs = new List<Construct>();

    public Dictionary<string, GameObject> constructDict = new Dictionary<string, GameObject>();

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
        available = new Dictionary<string, int>();
        available["mine"] = 5;
        available["habitat"] = 2;
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

    public void AddBuilding(Transform surface) {
        GameObject construct = SelectedConstruct();
        if (construct != null) {
            Vector3 tempPosition = surface.position + (surface.forward * -0.5f);
            Vector3Int constructPosPotential = new Vector3Int(Mathf.RoundToInt(tempPosition.x), 
                                            Mathf.RoundToInt(tempPosition.y), 
                                            Mathf.RoundToInt(tempPosition.z));
            if (!buildings.ContainsKey(constructPosPotential)) {
                buildings.Add(constructPosPotential, Instantiate(construct, surface));
                available[selected]--;
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
         }
    }
}
