using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetReached : MonoBehaviour
{
    public float threshold=0.02f;
    public Transform targetTransform;
    public UnityEvent OnReached;
    private bool wasReached = false;
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, targetTransform.position);
        if (distance < threshold && !wasReached)
        {
            OnReached.Invoke();
            wasReached = true;
        }else if (distance >= threshold)
        {
            wasReached = false;
        }
    }
}
