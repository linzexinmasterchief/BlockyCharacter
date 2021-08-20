using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portal_target;
    public bool isTriggerPortal;

    // function used to start teleportation
    private void OnTriggerEnter(Collider collider)
    {
        Teleportation.Teleport(collider.gameObject, portal_target);
    }
}
