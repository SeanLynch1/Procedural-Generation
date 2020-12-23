using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGeneration : MonoBehaviour
{
    public float rayDistance;
    public int maxListLimit = 7;
    public List<GameObject> buildingBlocks;
    public List<GameObject> trackOfBlocks;
    int randomNumber;
    GameObject instantiatedBlock;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 5);
        InstantiateFractal();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void InstantiateFractal()
    {
        GameObject addedBlock;
        RaycastHit hit;
        switch (randomNumber)
        {
            case 1:
                if(Physics.Raycast(this.transform.position,transform.TransformDirection(Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayDistance, Color.yellow);
                    addedBlock = instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0,buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.right) * rayDistance,Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(addedBlock);
                }
                break;
            case 2:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * rayDistance, Color.yellow);
                    addedBlock = instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.right) * rayDistance, Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(addedBlock);
                }
                break;
            case 3:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);
                    addedBlock = instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.forward) * rayDistance, Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    trackOfBlocks.Add(addedBlock);
                }
                break;
            case 4:
                Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * rayDistance, Color.yellow);
                addedBlock = instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.forward) * rayDistance, Quaternion.identity);
                addedBlock.transform.parent = this.gameObject.transform;
                trackOfBlocks.Add(addedBlock);
                break;
            default:
                return;
        }
    }
}
