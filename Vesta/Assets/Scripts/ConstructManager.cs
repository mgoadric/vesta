using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Construct {
    public string name;
    public GameObject prefab;
}

public class ConstructManager : MonoBehaviour
{

    public List<Construct> constructs = new();

    public Dictionary<string, GameObject> constructDict = new();

    public Dictionary<string, int> available;

    public GameObject availableButton;

    public GameObject availableContent;

    public string selected;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Construct construct in constructs) {
            constructDict[construct.name] = construct.prefab;
        }
        available = new Dictionary<string, int>
        {
            ["mine"] = 3,
            ["storage"] = 1,
            ["habitat"] = 1
        };
    }


    void DeltaAvailable(string which, int amount) {
        if (!available.ContainsKey(which)) {
            available[which] = 0;
        }
        available[which] += amount;
        if (available[which] < 0) {
            available[which] = 0;
        }
    }

    void SetSelected(string which) {
            selected = which;
    }

    public GameObject SelectedConstruct() {
        if (selected != null && available.ContainsKey(selected) && available[selected] > 0) {
            return constructDict[selected];
        } else {
            return null;
        }
    }

    public GameObject AddBuilding() {
        GameObject construct = SelectedConstruct();
        if (construct != null) {
            DeltaAvailable(selected, -1);
            if (available[selected] == 0) {
                selected = "none";
            }  
            return construct;   
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string s in available.Keys) {
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
