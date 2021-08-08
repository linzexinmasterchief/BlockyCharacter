using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portal_target;

    // function used to start teleportation
    void Teleport(GameObject teleportObject, Transform TargetTransform)
    {
        teleportObject.transform.position = TargetTransform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Teleport(collider.gameObject, portal_target);
    }
}
