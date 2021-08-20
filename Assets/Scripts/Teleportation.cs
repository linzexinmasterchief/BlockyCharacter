using UnityEngine;

// static interface used for teleportation
public static class Teleportation
{
    public static void Teleport(GameObject teleportObject, Transform TargetTransform)
    {
        teleportObject.transform.position = TargetTransform.position;
    }
}
