using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    public Animator animator;
    private bool isTPS;

    // Start is called before the first frame update
    void Start()
    {
        isTPS = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTPS)
        {
            animator.SetBool("isTPS", true);
        }
        else
        {
            animator.SetBool("isTPS", false);
        }
    }

    public void Switch()
    {
        isTPS = !isTPS;
    }
}
