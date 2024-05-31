using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Face {
    NORTH,
    EAST,
    SOUTH,
    WEST,
    UP,
    DOWN
}

public class Chunk : MonoBehaviour
{

    public GameObject surfacePrefab;

    public static Dictionary<Face, Vector3> facePositions = new Dictionary<Face, Vector3>() {
        { Face.NORTH, new Vector3(0, 0, 0.5f) },
        { Face.EAST, new Vector3(0.5f, 0, 0) },
        { Face.SOUTH, new Vector3(0, 0, -0.5f) },
        { Face.WEST, new Vector3(-0.5f, 0, 0) },
        { Face.UP, new Vector3(0, 0.5f, 0) },
        { Face.DOWN, new Vector3(0, -0.5f, 0) },
    };

    public static Dictionary<Face, Vector3> faceRotations = new Dictionary<Face, Vector3>() {
        { Face.NORTH, new Vector3(0, 180, 0) },
        { Face.EAST, new Vector3(0, -90, 0) },
        { Face.SOUTH, new Vector3(0, 0, 0) },
        { Face.WEST, new Vector3(0, 90, 0) },
        { Face.UP, new Vector3(90, 0, 0) },
        { Face.DOWN, new Vector3(-90, 0, 0) },
    };

    public Dictionary<Face, GameObject> surfaces = new Dictionary<Face, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Face face in Enum.GetValues(typeof(Face)))
        {
            surfaces[face] = Instantiate(surfacePrefab, transform.position + facePositions[face], Quaternion.Euler(faceRotations[face]), transform);
            surfaces[face].name = face.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
