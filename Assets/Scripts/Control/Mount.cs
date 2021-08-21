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
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        movement = Car.transform.position - People.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick()
    {
        if (IsPeopleInTheCar == false)
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            movement = Car.transform.position - People.transform.position;
            People.GetComponent<BlockyMove>().enabled = false;
            People.GetComponent<CharacterController>().enabled = false;
            People.GetComponent<CapsuleCollider>().enabled = false;
            People.transform.position = Car.transform.position;
            People.transform.parent = Car.transform;

            Car.GetComponent<CarControl>().enabled = true;
        }
        else
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            People.transform.parent = null;
            People.transform.position = Car.transform.position - movement;
            People.GetComponent<CharacterController>().enabled = true;
            People.GetComponent<BlockyMove>().enabled = true;
            People.GetComponent<CapsuleCollider>().enabled = true;

            Car.GetComponent<CarControl>().enabled = false;
        }
    }
}
