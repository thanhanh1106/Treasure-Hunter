using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material material;
    float distance;
    [Range(0f, 1f)] public float speed = 0.02f;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        distance += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
