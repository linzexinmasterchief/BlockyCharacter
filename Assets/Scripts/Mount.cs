using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{
    public bool IsPeopleInTheCar = false;
    public GameObject Car;
    public GameObject People;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        
        
        btn.onClick.AddListener(onClick);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onClick()
    {
        if (IsPeopleInTheCar == false)
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            Vector3 movement = Car.transform.position - People.transform.position;
            People.transform.position = Car.transform.position;
            People.gameObject.SetActive(false);
        }
        else
        {
            IsPeopleInTheCar = !IsPeopleInTheCar;
            People.transform.position = Car.transform.position - movement;
            People.gameObject.SetActive(true);
        }
    }
}
