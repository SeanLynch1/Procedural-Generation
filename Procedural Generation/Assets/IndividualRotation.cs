using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualRotation : MonoBehaviour
{
    [Header("Vectors")]
    private Vector3 randomDirection;
    void Start()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                randomDirection = Vector3.forward;
                break;
            case 1:
                randomDirection = Vector3.right;
                break;
            case 2:
                randomDirection = Vector3.up;
                break;
            default:
                return;
        }
    }
    void Update()
    {
        RotateBlockIndividually();
    }
    public void RotateBlockIndividually()
    {
        if (ToggleControl.rotateIndividually)
        {
            this.gameObject.transform.RotateAround(this.transform.position, randomDirection, 45 * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.eulerAngles = Vector3.zero;
            this.gameObject.transform.RotateAround(this.transform.position, Vector3.up, 0 * Time.deltaTime);
        }
    }
}
