using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public static bool rotateLeft;
    public static bool rotateRight;

    public void RotateLeft()
    {
        rotateLeft = true;
        rotateRight = false;
    }
    public void Stop()
    {
        rotateLeft = false;
        rotateRight = false;
    }
    public void RotateRight()
    {
        rotateRight = true;
        rotateLeft = false;
    }
}
