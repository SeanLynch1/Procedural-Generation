using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGeneration : MonoBehaviour
{
    public float rayDistance;
    public int maxListLimit = 7;
    public List<GameObject> buildingBlocks;
    public List<GameObject> trackOfBlocks;
    public BuildingGenerator buildingGenerator;
    int randomNumber;
    GameObject instantiatedBlock;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 5);
        buildingGenerator = GetComponentInParent<BuildingGenerator>();
        for(int i = 10; i < buildingGenerator.instantiatedBlocks.Count; i ++)
        {
            if (this.gameObject == buildingGenerator.instantiatedBlocks[i])
                InstantiateFractal();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void InstantiateFractal()
    {
        RaycastHit hit;
        switch (randomNumber)
        {
            case 1:
                if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.right) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(instantiatedBlock);
                }
                break;
            case 2:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.right) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(instantiatedBlock);
                }
                break;
            case 3:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.forward) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(instantiatedBlock);
                }
                break;
            case 4:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.forward), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.forward) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(instantiatedBlock);
                }
                break;
            default:
                return;
        }
    }
}
