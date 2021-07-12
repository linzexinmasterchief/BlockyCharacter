using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public Vector3[] route;
    public float speed;

    private int route_index;

    private Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        int route_point_count = transform.Find("RoutePoints").childCount;
        route = new Vector3[route_point_count];
        for (int i = 0; i < route_point_count; i++)
        {
            route[i] = transform.Find("RoutePoints").GetChild(i).position;
        }
        route_index = 0;

        platform = transform.Find("Platform");
        platform.position = route[route_index];
    }

    private void FixedUpdate()
    {
        if ((platform.position - route[route_index]).sqrMagnitude < 0.01f)
        {
            route_index++;
            if (route_index >= route.Length)
            {
                route_index = 0;
            }
        }

        Vector3 v = Vector3.zero;
        platform.position = Vector3.SmoothDamp(platform.position, route[route_index], ref v, Time.fixedDeltaTime / speed);

    }
}
