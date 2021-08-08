using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject TargetDoor;
    public Transform target_transform;
    public Transform object_transform;

    // function used to start teleportation
    void Teleport(GameObject teleportObject, Transform TargetTransform)
    {
        object_transform.position = target_transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        object_transform = collider.transform;
        Transform TargetTransform = TargetDoor.transform;
        Teleport(collider.gameObject, TargetTransform);
    }
}
