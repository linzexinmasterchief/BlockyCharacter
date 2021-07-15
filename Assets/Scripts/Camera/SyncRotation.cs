using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRotation : MonoBehaviour
{

    public Transform cam1;
    public Transform cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam2.rotation = Quaternion.Euler(new Vector3(0, cam1.rotation.y, 0));
    }
}
