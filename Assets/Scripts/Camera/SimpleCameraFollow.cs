using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;
    public float follow_speed;
    public bool look_at_target;
    public Vector3 look_at_delta;

    private Transform holding_obj;
    private bool is_holding;

    private Vector3 delta_pos;
    
    // Start is called before the first frame update
    void Start()
    {
        delta_pos = target.position - transform.position;
        is_holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cam_target_pos =
            target.position
            - target.transform.forward * delta_pos.z
            - target.transform.up * delta_pos.y
            - target.transform.right * delta_pos.x;

        transform.position = Vector3.Lerp(transform.position, cam_target_pos, follow_speed * Time.deltaTime);
        if (look_at_target)
        {
            transform.LookAt(
                target.position
                - target.transform.right * look_at_delta.x
                + target.transform.up * look_at_delta.y);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!is_holding)
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    holding_obj = hit.transform;
                    holding_obj.parent = transform;
                    is_holding = true;
                }
            }
            else
            {
                holding_obj.parent = null;
                is_holding = false;
            }

        }
    }
}
