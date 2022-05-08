using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPose : MonoBehaviour
{
    private XRGrabInteractable xrGrabInteractable;
    private bool leftHold;
    private bool rightHold;
    public SkinnedMeshRenderer leftRenderer;
    public SkinnedMeshRenderer rightRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        leftHold = false;
        rightHold = false;
        xrGrabInteractable = GetComponentInParent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeActive()
    {
        if (leftHold == true)
        {
            leftRenderer.enabled = false;
            leftHold = false;
        }
        else
        {
            rightRenderer.enabled = false;
            rightHold = false;
        }
        // SkinnedMeshRenderer skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        // skinnedMeshRenderer.enabled = false;
    }
    
    public void SetActive()
    {
        if (xrGrabInteractable.selectingInteractor.tag.Equals("Lefthand"))
        {
            leftRenderer.enabled = true;
            leftHold = true;
        }
        else
        {
            rightRenderer.enabled = true;
            rightHold = true;
        }
        // SkinnedMeshRenderer skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        // skinnedMeshRenderer.enabled = true;
    }
}
