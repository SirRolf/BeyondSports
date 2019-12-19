using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move(float x,float z, float y)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(x * 0.01f, z * 0.01f, y * 0.01f), 4);
    }
}
