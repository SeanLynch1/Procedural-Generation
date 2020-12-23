using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPathway : MonoBehaviour
{
    InstantiateRoads instantiateRoads;
    public GameObject roadPrefab;
    public GameObject cornerRoadPrefab;
    public GameObject emptyPrefab;
    private float rayDistance = 5;
    public Vector3 randomDirection;
    Vector3 RandomDirection
    {
        get
        {
            for(int i = 0; i < 4; i ++)
            {
                int n = i;
                switch (n)
                {
                    case 0:
                        randomDirection = Vector3.right;
                        break;
                    case 1:
                                randomDirection = -Vector3.right;
                        break;
                    case 2:
                                randomDirection = Vector3.forward;
                        break;
                    case 3:
                                randomDirection = -Vector3.forward;
                        break;
                }
            }
            return randomDirection;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        instantiateRoads = FindObjectOfType<InstantiateRoads>();
        if(instantiateRoads.roadTiles.Count < instantiateRoads.maxRoads)
        {
            ShootRays();
        }

    }
    private void FixedUpdate()
    {
       
        Debug.DrawRay(this.gameObject.transform.position, transform.forward * rayDistance, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(1, 0, 1)), out hit, rayDistance))
        {
            if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(1, 0, -1)), out hit, rayDistance))
            {
                if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(-1, 0, 1)), out hit, rayDistance))
                {
                    if (Physics.Raycast(this.transform.position, transform.TransformDirection(new Vector3(-1, 0, -1)), out hit, rayDistance))
                    {
                        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.right), out hit, rayDistance))
                        {
                            if (Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.right), out hit, rayDistance))
                            {
                                if (Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.forward), out hit, rayDistance))
                                {
                                    if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
                                    {
                                        this.gameObject.SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
    public void GenerateDirection()
    {
        GameObject newRoad = Instantiate(roadPrefab, this.transform.position + RandomDirection * 5, Quaternion.identity);
        newRoad.transform.parent = this.transform;
        instantiateRoads.roadTiles.Add(newRoad);
    }
    public void ShootRays()
    {
        RaycastHit hit;
        int randomNumber = Random.Range(0, 4);
        int degrees = 0;

        for (int i = 0; i < 8; i++)
        {
            for(int j =0; j < 8; j ++)
            {
                int n = Random.Range(0, 4);
                switch (n)
                {
                    case 0:
                        degrees += 90;
                        break;
                    case 1:
                        degrees += 180;
                        break;
                    case 2:
                        degrees += 270;
                        break;
                    case 3:
                        degrees += 360;
                        break;
                }

                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + degrees, this.transform.rotation.z);
                if (!Physics.Raycast(this.transform.position, transform.forward * rayDistance, out hit, rayDistance))
                {
                   
                    GameObject spaceAvailabilityDetector = Instantiate(roadPrefab, this.transform.position + transform.forward * rayDistance, Quaternion.identity);
                    spaceAvailabilityDetector.transform.parent = this.gameObject.transform.parent;
                    instantiateRoads.roadTiles.Add(spaceAvailabilityDetector);
                    return;
                }
            }
        }
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Road Block")
        {
            collision.gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road Block")
        {
            this.gameObject.SetActive(false);
        }
    }
}
