using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SquareGrid : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    [SerializeField] int height;
    [SerializeField] int width;

    [SerializeField] float cellSize;
    [SerializeField] float heightFactor;

    [SerializeField] Texture2D heightMap;

    void Start()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();

        Vector3[] vertices = Vertices();
        int[] triangles = Indices();

        Debug.Log(vertices.Length);
        Debug.Log(triangles.Length);

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = triangles;
        meshFilter.mesh.RecalculateNormals();
    }

    
    Vector3[] Vertices()
    {
        Vector3[] vertices = new Vector3[(height + 1) * (width + 1)];

        for (int z = 0; z <= height; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                Color color = heightMap.GetPixel(x, -z);

                float xPos = x * cellSize;
                float zPos = z * cellSize;

                int index = z * (width + 1) + x; //calculating 1D index for a 2D grid

                vertices[index] = new Vector3(xPos, color.r * heightFactor, zPos); //creating a new vector3 for each vertex
            }
        }

        return vertices;
    }

    int[] Indices()
    {
        int[] triangles = new int[(height * width) * 6];

        int index = 0;

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                int vertexIndex = z * (width + 1) + x;

                //left triangle
                triangles[index++] = vertexIndex;
                triangles[index++] = vertexIndex + width + 1;
                triangles[index++] = vertexIndex + 1;

                //right triangle
                triangles[index++] = vertexIndex + 1;
                triangles[index++] = vertexIndex + width + 1;
                triangles[index++] = vertexIndex + width + 2;
            }
        }

        return triangles;
    }
}
