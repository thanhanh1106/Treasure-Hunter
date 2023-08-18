using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] float Speed;
    float rightPosX = 15f;
    float leftPosX = -15f;
    private void Update()
    {
        transform.position += Vector3.left * Speed*Time.deltaTime;
        if(transform.position.x < leftPosX)
            transform.position = new Vector3(rightPosX, transform.position.y, transform.position.z);
    }
}
