using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPathway : MonoBehaviour
{
    InstantiateRoads instantiateRoads;
    InstantiateTowers instantiateTowers;
    public GameObject roadPrefab;
    public GameObject towerPrefab;
    private float rayDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        instantiateRoads = FindObjectOfType<InstantiateRoads>();
        instantiateTowers = FindObjectOfType<InstantiateTowers>();
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
        int number = 0;
        if(CheckSides(number))
        {
            Debug.Log("number = " + number);
            this.gameObject.SetActive(false);
            GameObject tile = Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            tile.gameObject.transform.parent = instantiateTowers.gameObject.transform;
            instantiateTowers.tileList.Add(tile);
        }
    }

    public void ShootRays()
    {
        RaycastHit hit;
        int randomNumber = Random.Range(0, 10);

        for (int j = 0; j < 4; j++)
        {
            int degrees = 0;
            int n = Random.Range(0, 7);
            switch (n)
            {
                case 0:
                    degrees += 0;
                    break;
                case 1:
                    degrees -= 90;
                    break;
                case 2:
                    degrees += 90;
                    break;
                default:
                    degrees += 0;
                    break;
            }
            Debug.Log("Degrees = " + degrees);

            if (!Physics.Raycast(this.transform.position, transform.forward * rayDistance, out hit, rayDistance))
            {
                GameObject spaceAvailabilityDetector = Instantiate(roadPrefab, this.transform.position + transform.forward * rayDistance, this.transform.rotation);
                spaceAvailabilityDetector.transform.parent = this.gameObject.transform.parent;
                instantiateRoads.roadTiles.Add(spaceAvailabilityDetector);
            }
            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y + degrees, this.transform.rotation.z);
        }
    }
    private bool CheckSides(int n)
    {
        RaycastHit hit;
        if (!Physics.Raycast(this.transform.position, transform.forward * rayDistance, out hit, rayDistance))
        {
            n += 1;
        }
        if (!Physics.Raycast(this.transform.position, -transform.forward * rayDistance, out hit, rayDistance))
        {
            n += 1;
        }
        if (!Physics.Raycast(this.transform.position, transform.right * rayDistance, out hit, rayDistance))
        {
            n += 1;
        }
        if (!Physics.Raycast(this.transform.position, -transform.right * rayDistance, out hit, rayDistance))
        {
            n += 1;
        }
        if (n == 4)
            return true;
        else
            return false;
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
