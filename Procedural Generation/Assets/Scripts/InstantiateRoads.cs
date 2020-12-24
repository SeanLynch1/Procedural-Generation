using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoads : MonoBehaviour
{
    public GameObject roadTile;
     public List<GameObject> roadTiles = new List<GameObject>();
    private float distance = 5;
    public float maxRoads = 130;


    void Start()
    {
        BeginRoadNetworkSystem();
    }

    public void BeginRoadNetworkSystem()
    {
        for (int i = 0; i < 4; i++)
        {
            int n = i;
            GameObject road;

            switch (n)
            {
                case 0:
                    road = Instantiate(roadTile, this.transform.position + transform.TransformDirection(Vector3.right) * distance, Quaternion.identity);
                    road.transform.rotation = Quaternion.Euler(road.transform.rotation.x,road.transform.rotation.y + 90,road.transform.rotation.z);
                    road.transform.parent = this.gameObject.transform;
                    InstantiateRoad(road);
                    break;
                case 1:
                    road = Instantiate(roadTile, this.transform.position + transform.TransformDirection(-Vector3.right) * distance, Quaternion.identity);
                    road.transform.rotation = Quaternion.Euler(road.transform.rotation.x, road.transform.rotation.y - 90, road.transform.rotation.z);
                    road.transform.parent = this.gameObject.transform;
                    InstantiateRoad(road);
                    break;
                case 2:
                    road = Instantiate(roadTile, this.transform.position + transform.TransformDirection(Vector3.forward) * distance, Quaternion.identity);
                    road.transform.rotation = Quaternion.Euler(road.transform.rotation.x, road.transform.rotation.y, road.transform.rotation.z);
                    road.transform.parent = this.gameObject.transform;
                    InstantiateRoad(road);
                    break;
                case 3:
                    road = Instantiate(roadTile, this.transform.position + transform.TransformDirection(-Vector3.forward) * distance, Quaternion.identity);
                    road.transform.rotation = Quaternion.Euler(road.transform.rotation.x, road.transform.rotation.y + 180, road.transform.rotation.z);
                    road.transform.parent = this.gameObject.transform;
                    InstantiateRoad(road);
                    break;
            }
        }
    }
    public void InstantiateRoad(GameObject r)
    {
        r.transform.parent = this.transform;
        roadTiles.Add(r);
    }
}
