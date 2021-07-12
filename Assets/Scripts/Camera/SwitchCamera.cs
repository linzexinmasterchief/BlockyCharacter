using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        cam1.gameObject.active = !cam1.gameObject.active;
        cam2.gameObject.active = !cam2.gameObject.active;
    }
}
