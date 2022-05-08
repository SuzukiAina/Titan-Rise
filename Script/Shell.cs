using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    // Start is called before the first frame update
    public float shellSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = -1 * transform.right * shellSpeed;
        Destroy(this,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
