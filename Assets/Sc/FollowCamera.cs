using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 dist;
    public GameObject target;
    void Start()
    {
        dist = transform.position - target.transform.position;
    }

    void Update()
    {
        transform.position = target.transform.position + dist;
    }
}
