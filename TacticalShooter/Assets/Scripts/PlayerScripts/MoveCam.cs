using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform playerPos;
    void Update()
    {
        transform.position = playerPos.position;
    }
}
