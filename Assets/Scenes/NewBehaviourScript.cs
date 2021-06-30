using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform target;

    const float followDistance = 1.0f;

    void Update()
    {
        transform.position = target.position + (transform.position - target.position).normalized * followDistance;
    }
}
