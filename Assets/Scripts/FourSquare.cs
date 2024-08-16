using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourSquare : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();

        Vector3[] vertices1 = new Vector3[]
        {
            new Vector3 (1, -1f, 0f), //0
            new Vector3 (0f, -1f, 0f),//1
            new Vector3 (-1f, -1f, 0f),//2
            new Vector3(-1f, 0f, 0f),//3
            new Vector3(-1f, 1f, 0f),//4
            new Vector3(0f, 1f, 0f),//5
            new Vector3(1f, 1f, 0f),//6
            new Vector3(1f, 0f, 0f),//7
            new Vector3(0, 0, 0),//8
        };

        int[] indices1 = new int[]
        {
            0, 1, 8,
            0, 8, 7,
            1, 2, 3,
            1, 3, 8,
            8, 3, 4,
            8, 4 , 5,
            7, 8, 5,
            7, 5, 6
        };

        meshFilter.mesh.vertices = vertices1;
        meshFilter.mesh.triangles = indices1;
    }
}
