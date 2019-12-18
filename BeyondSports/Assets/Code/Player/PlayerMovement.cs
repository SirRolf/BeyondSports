using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Move(float x, float y)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(x * 0.01f, 0, y * 0.01f), 4);
    }
}
