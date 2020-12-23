using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGeneration : MonoBehaviour
{
    public float rayDistance;
    public List<GameObject> buildingBlocks;
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
        RaycastHit hit;
        switch (randomNumber)
        {
            case 1:
                if(Physics.Raycast(this.transform.position,transform.TransformDirection(Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * rayDistance, Color.yellow);
                     instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0,buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.right) * rayDistance,Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    AddBlock();
                }
                break;
            case 2:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(-Vector3.right), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.right) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    AddBlock();
                }
                break;
            case 3:
                if (!Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance) == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);
                    instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(Vector3.forward) * rayDistance, Quaternion.identity);
                    instantiatedBlock.transform.parent = this.gameObject.transform;
                    AddBlock();
                }
                break;
            case 4:
                Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * rayDistance, Color.yellow);
                instantiatedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count - 1)], this.transform.position + transform.TransformDirection(-Vector3.forward) * rayDistance, Quaternion.identity);
                instantiatedBlock.transform.parent = this.gameObject.transform;
                AddBlock();
                break;
            default:
                return;

        }

    }
    public void AddBlock()
    {
        GameObject addedBlock;
        int blockIterationLength;
        blockIterationLength = Random.Range(5, 10);
        for (int i = 0; i < blockIterationLength; i++)
        {
            int increasingValue = 0;
            int increasingValue2 = 0;
            int increasingValue3 = 0;

            int randomValue = Random.Range(1, 4);
            switch (randomValue)
            {
                case 1:
                    increasingValue += 5;
                    addedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count)], new Vector3(instantiatedBlock.transform.position.x + increasingValue, instantiatedBlock.transform.position.y, instantiatedBlock.transform.position.z), Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    break;
                case 2:
                    increasingValue2 += 5;
                    addedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count)], new Vector3(instantiatedBlock.transform.position.x, instantiatedBlock.transform.position.y + increasingValue2, instantiatedBlock.transform.position.z), Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    break;
                case 3:
                    increasingValue3 += 5;
                    addedBlock = Instantiate(buildingBlocks[Random.Range(0, buildingBlocks.Count)], new Vector3(instantiatedBlock.transform.position.x, instantiatedBlock.transform.position.y, instantiatedBlock.transform.position.z + increasingValue3), Quaternion.identity);
                    addedBlock.transform.parent = this.gameObject.transform;
                    break;
                default:
                    return;
            }

        }
    }
}
