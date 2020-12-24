using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControl : MonoBehaviour
{
    public static bool rotateIndividually;
    public void RotateIndividualBlock()
    {
        rotateIndividually = !rotateIndividually;
        Debug.Log("Toggle Pressed"); 
    }
}
