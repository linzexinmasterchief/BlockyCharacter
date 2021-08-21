using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mount : MonoBehaviour
{
    public bool IsPeopleInTheCar = false;
    public GameObject Car;
    public GameObject People;
    public Vector3 movement;

    void Start()
    {
        // initialize
        movement = Car.transform.position - People.transform.position;
    }

    public void onClick()
    {
        if (IsPeopleInTheCar == false)
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            movement = Car.transform.position - People.transform.position;
            // the order of disable is important
            People.GetComponent<BlockyMove>().enabled = false;
            People.GetComponent<CharacterController>().enabled = false;
            People.GetComponent<CapsuleCollider>().enabled = false;

            People.transform.position = Car.transform.position;
            // need this line to sync player position with car position
            // move the player into car last
            People.transform.parent = Car.transform;

            // enable car control
            Car.GetComponent<CarControl>().enabled = true;
        }
        else
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            // disable car control
            Car.GetComponent<CarControl>().enabled = false;
            // move player out from car first
            People.transform.parent = null;
            People.transform.position = Car.transform.position - movement;
            // the order of enable is important, be aware the order is different from disable
            People.GetComponent<CharacterController>().enabled = true;
            People.GetComponent<BlockyMove>().enabled = true;
            People.GetComponent<CapsuleCollider>().enabled = true;

        }
    }
}
