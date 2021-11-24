using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mount : MonoBehaviour
{
    public bool IsPeopleInTheCar = false;
    public GameObject Car;
    public GameObject Player;
    public Vector3 movement;

    void Start()
    {
        // initialize
        movement = Car.transform.position - Player.transform.position;
    }

    public void onClick()
    {

        if (IsPeopleInTheCar == false)
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            movement = Car.transform.position - Player.transform.position;
            // the order of disable is important
            Player.GetComponent<BlockyMove>().enabled = false;
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<CapsuleCollider>().enabled = false;

            Player.transform.position = Car.transform.position;
            // need this line to sync player position with car position
            // move the player into car last
            Player.transform.parent = Car.transform;

            // enable car control
            Car.GetComponent<CarControl>().enabled = true;
        }
        else
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            // disable car control
            Car.GetComponent<CarControl>().enabled = false;
            // move player out from car first
            Player.transform.parent = null;
            Player.transform.position = Car.transform.position - movement;
            // the order of enable is important, be aware the order is different from disable
            Player.GetComponent<CharacterController>().enabled = true;
            Player.GetComponent<BlockyMove>().enabled = true;
            Player.GetComponent<CapsuleCollider>().enabled = true;

        }
    }
}
