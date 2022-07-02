using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 自動で消える
public class ObjectMove : MonoBehaviour {
    public float timer = 15.0f;
    void Start () {
        Destroy (gameObject, timer);
    }
}