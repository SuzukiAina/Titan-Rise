using System;
using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateObject : MonoBehaviour
{
    public GameObject targetObject;
    public Transform parentTransform;
    
    private GameObject currentObject;
    private List<GameObject> magazineList;
    private bool visible;
    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        transform.position = new Vector3(parentTransform.position.x,parentTransform.position.y,parentTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (visible)
        {
            if (currentObject == null)
            {
                var magazineObject=Instantiate(targetObject);
                magazineObject.transform.position = transform.position; 
                currentObject = magazineObject;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(parentTransform.position.x,parentTransform.position.y,parentTransform.position.z);
        transform.rotation=Quaternion.Euler(new Vector3(parentTransform.transform.eulerAngles.x,parentTransform.transform.eulerAngles.y,parentTransform.transform.eulerAngles.z));
    }

    public void InstantiateMagazine()
    {
        currentObject = null;
    }

    // public void DestroyPrefabs()
    // {
    //     foreach(var obj in magazineList)
    //     {
    //         Destroy(obj);
    //     }
    //     currentObject = null;
    // }

    public void ActiveOutline()
    {
        Outlinable outlinable = currentObject.GetComponent<Outlinable>();
        outlinable.enabled = true;
    }
    
    public void DeActiveOutline()
    {
        Outlinable outlinable = currentObject.GetComponent<Outlinable>();
        outlinable.enabled = false;
    }

    public void DeactiveCurrent()
    {
        visible = false;
        Destroy(currentObject);
        currentObject = null;
    }
    
    public void ActiveCurrent()
    {
        visible = true;
    }
}
