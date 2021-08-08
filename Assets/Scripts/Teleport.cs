// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Teleport : MonoBehaviour
// {
//     public GameObject transferObject;
//     public GameObject transferDoor1;
//     public GameObject transferDoor2;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void Teleportion(GameObject teleportObject, Transform TargetTransform)
//     {
//         transferObject = teleportObject;
//         transferDoor2.transform.position = TargetTransform.position;
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.CompareTag("Transfer1"))
//         {
//             transferObject.transform.position = transferDoor2.transform.position;
//         }
//         if (other.gameObject.CompareTag("Transfer2"))
//         {
//             transferObject.transform.position = transferDoor1.transform.position;
//         }
//     }
// }
