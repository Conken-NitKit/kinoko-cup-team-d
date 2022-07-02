using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
 public float deleteTime = 3.0f;

    // Use this for initialization
void Start()
{
        Destroy(gameObject, deleteTime);
}

    // Update is called once per frame
void Update()
{

    }
}

