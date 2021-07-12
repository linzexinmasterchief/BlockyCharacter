using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrab : MonoBehaviour
{

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        triggered = !triggered;
    }
}
