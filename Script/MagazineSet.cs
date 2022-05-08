using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSet : MonoBehaviour
{
    public Transform cameraTransform;

    public float xAxisOffset;
    public float yAxisOffset;
    public float zAxisOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x+xAxisOffset,cameraTransform.position.y+yAxisOffset,cameraTransform.position.z+zAxisOffset);
        transform.rotation=Quaternion.Euler(new Vector3(0,cameraTransform.transform.eulerAngles.y,0));
    }
}
