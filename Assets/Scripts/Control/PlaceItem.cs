using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void place()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            Vector3 hit_point = hit.point;
            gameObject.transform.position = hit_point;
            gameObject.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
            Instantiate(gameObject);
        }
    }
}
