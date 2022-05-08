using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    public GameObject handPrefab;
    public InputDeviceCharacteristics inputDeviceCharacteristics;
    public bool hideHandOnSelect=false;
    private InputDevice targetDevice;
    private Animator handAnimator;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private float thumbValue;
    void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics,devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject spawnedHand = Instantiate(handPrefab, transform);
            handAnimator = spawnedHand.GetComponent<Animator>();
            skinnedMeshRenderer = spawnedHand.GetComponentInChildren<SkinnedMeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            InitializeHand();
        }
        else
        {
            UpdateHand();
        }
    }

    private void UpdateHand()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip",gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip",0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger",triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger",0);
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool thumb1Bool);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool thumb2Bool);
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool thumb3Bool);
        if (thumb1Bool || thumb2Bool || thumb3Bool)
        {
            thumbValue = Mathf.Lerp(thumbValue, 1, Time.deltaTime * 10);
            handAnimator.SetFloat("Thumb",thumbValue);
        }
        else
        {
            thumbValue = Mathf.Lerp(thumbValue, 0, Time.deltaTime * 10);
            handAnimator.SetFloat("Thumb",thumbValue);
        }
    }

    public void HideHandOnSelect()
    {
        if (hideHandOnSelect)
        {
            skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
        }
    }
}
