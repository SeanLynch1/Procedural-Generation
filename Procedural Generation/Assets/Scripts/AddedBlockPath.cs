using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedBlockPath : MonoBehaviour
{
    public FractalGeneration fractalGeneration;

    public float distance = 252;

    public Vector3 randomDirection;
    public Vector3 RandomDirection
    {
        get
        {
            int n = Random.Range(1, 7);
            switch (n)
            {
                case 1:
                    randomDirection = -Vector3.forward;
                    break;
                case 2:
                    randomDirection = Vector3.forward;
                    break;
                case 3:
                    randomDirection = Vector3.right;
                    break;
                case 4:
                    randomDirection = -Vector3.right;
                    break;
                case 5:
                    randomDirection = Vector3.up;
                    break;
                case 6:
                    randomDirection = -Vector3.up;
                    break;
                default:
                    break;
            }
            return randomDirection;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fractalGeneration = gameObject.GetComponentInParent<FractalGeneration>();
        AddBlock();
    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject addedBlock;

    public void AddBlock()
    {
        fractalGeneration = gameObject.GetComponentInParent<FractalGeneration>();
        if (fractalGeneration.trackOfBlocks.Count <= fractalGeneration.maxListLimit)
        {
            addedBlock = Instantiate(fractalGeneration.buildingBlocks[Random.Range(0, fractalGeneration.buildingBlocks.Count)], this.transform.position + transform.TransformDirection(RandomDirection) * distance, Quaternion.identity);
            addedBlock.transform.parent = this.gameObject.transform.parent;
            fractalGeneration.trackOfBlocks.Add(addedBlock);
        }
        else
            return;
    }
    public void OnCollisionEnter(Collision collision)
    {
        fractalGeneration = gameObject.GetComponentInParent<FractalGeneration>();
        Debug.Log("Destroy Me");
        if (collision.gameObject.tag == "PrimaryBlock" && this.gameObject != fractalGeneration.trackOfBlocks[0].gameObject)
            this.gameObject.SetActive(false);
    }

}
