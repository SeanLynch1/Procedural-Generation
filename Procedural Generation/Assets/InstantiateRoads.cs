using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoads : MonoBehaviour
{
    public GameObject roadTile;
    private List<GameObject> roadTiles = new List<GameObject>();
    private float distance = 5;


    void Start()
    {
        BeginRoadNetworkSystem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginRoadNetworkSystem()
    {
        for (int i = 0; i < 4; i++)
        {
            int n = i;
            switch (n)
            {
                case 0:
                    GameObject road;
                    road = Instantiate(roadTile, this.transform.position + transform.TransformDirection(Vector3.right) * distance, Quaternion.identity);
                    road.transform.parent = this.transform;
                    roadTiles.Add(road);
                    break;
                case 1:
                    GameObject road1;
                    road1 = Instantiate(roadTile, this.transform.position + transform.TransformDirection(-Vector3.right) * distance, Quaternion.identity);
                    road1.transform.parent = this.transform;
                    roadTiles.Add(road1);
                    break;
                case 2:
                    GameObject road2;
                    road2 = Instantiate(roadTile, this.transform.position + transform.TransformDirection(Vector3.forward) * distance, Quaternion.identity);
                    road2.transform.parent = this.transform;
                    roadTiles.Add(road2);
                    break;
                case 3:
                    GameObject road3;
                    road3 = Instantiate(roadTile, this.transform.position + transform.TransformDirection(-Vector3.forward) * distance, Quaternion.identity);
                    road3.transform.parent = this.transform;
                    roadTiles.Add(road3);
                    break;
            }
        }
    }
}
