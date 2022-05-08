using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private Outlinable outlinable;
    // Start is called before the first frame update
    void Start()
    {
        outlinable = GetComponent<Outlinable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeOutline()
    {
        outlinable.enabled = true;
    }

    public void deactiveOutline()
    {
        outlinable.enabled = false;
    }
}
