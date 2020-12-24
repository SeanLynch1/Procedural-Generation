using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [Header("Fields")]
    public int xSize;
    public int zSize;

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // StartCoroutine(CreateShape());
        CreateShape();
    }
    private void Update()
    {
        UpdateMesh();
    }
    public void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];//Continas vertices in a grid

        //Assign a position of each vertice on our grid

        for(int i = 0, z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <=xSize; x ++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6]; // amount of triangle points needed


        int vert = 0;
        int tris = 0;
        for(int z = 0; z < zSize; z ++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //Assign points for triangle3
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

              //  yield return new WaitForSeconds(0.0000000005f);
            }
            vert++;
        }
    }
    public void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        for(int i = 0; i < vertices.Length; i ++)
        {
          //  Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}
