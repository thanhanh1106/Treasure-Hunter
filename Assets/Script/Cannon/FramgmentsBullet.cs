using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FramgmentsBullet : MonoBehaviour
{
    Vector3[] startPosChild;
    GameObject[] childs;
    int childCount;
    private void Awake()
    {
        childCount = transform.childCount;
        startPosChild = new Vector3[childCount];
        childs = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
            startPosChild[i] = childs[i].transform.position;
        }
    }
    public void SetChild()
    {
        foreach (var child in childs)
        {
            child.transform.parent = null;
        }
    }
    private void OnDisable()
    {
        for(int i = 0;i < childCount; i++)
        {
            childs[i].transform.parent = transform;
            childs[i].transform.position = startPosChild[i];
        }
    }
}
