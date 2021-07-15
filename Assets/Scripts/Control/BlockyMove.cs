using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//[RequireComponent(typeof(Animator))]
public class BlockyMove : MonoBehaviour
{
    public float mass;

    public float target_speed;
    public float speed;
    public float turn_speed;
    private Animator anim;

    public CharacterController controller;
    public Transform camera_transform;
    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    public Transform mount_point;

    public TriggerGrab triggerGrab;

    public GameObject interact_button;

    private double gravity;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gravity = 0;

    }

    private void Update()
    {
        if (triggerGrab.triggered)
        {
            triggerGrab.triggered = false;
            if (mount_point.childCount == 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    Transform t = hit.transform;
                    if (t.tag == "Interactable")
                    {
                        t.SetParent(mount_point);
                        t.GetComponent<BoxCollider>().enabled = false;
                        t.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
            else
            {
                Transform t = mount_point.GetChild(0);
                t.parent = null;
                t.GetComponent<BoxCollider>().enabled = true;
                t.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // init
        if (controller.isGrounded)
        {
            gravity = 0;
            if (CrossPlatformInputManager.GetAxisRaw("Jump") == 1)
            {
                // jump thrust
                gravity = 3;
                target_speed = Mathf.Lerp(target_speed, 0, Time.deltaTime);
            }
            else
            {
                target_speed = 0;
            }
        }
        else
        {
            gravity -= 9.81 * Time.deltaTime;
        }
        target_speed = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));

        float move_angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        // make character move to direction based on camera direction
        float target_angle = move_angle + camera_transform.eulerAngles.y;

        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turn_smooth_velocity, turn_smooth_time);

        // make character always face the same direction as camera
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, camera_transform.eulerAngles.y, 0f), Time.deltaTime * 10);
        
        // smooth speed increase/decrease
        speed = Mathf.Lerp(anim.GetFloat("speed"), target_speed, Time.deltaTime * 10);
        Vector3 move_direction = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;

        
        controller.Move(move_direction * speed * 0.03f + new Vector3(0, (float) gravity * mass, 0));
        anim.SetFloat("speed", speed);

    }

    //Vector3 pos_to_parent = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {

        //pos_to_parent = transform.position;

    }

    private void OnTriggerStay(Collider other)
    {
        //transform.parent = other.transform;
        //transform.position += pos_to_parent;
        if (other.tag == "Interactable")
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.tag == "Interactable")
                {
                    interact_button.SetActive(true);
                }
                else
                {
                    interact_button.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //transform.parent = null;
        if (other.tag == "Interactable")
        {
            interact_button.SetActive(false);
        }
    }

}
