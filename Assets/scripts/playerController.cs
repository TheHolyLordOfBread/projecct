using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{

    Rigidbody rb;
    Transform CameraTransform;
    Vector2 direction;
    bool isGrounded;
    bool canJump;
    bool holdingOre;

    SpringJoint[] springs;

    [SerializeField] float rayLength;


    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;
    [Space(5)]
    [Header("Jump")]
    [SerializeField] float jumpForce = 1f;
    [Space(5)]
    [Header("Mining")]
    public float mineRange;
    public float grabSize;

    bool canPick;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        rb = gameObject.GetComponent<Rigidbody>();
        CameraTransform = Camera.main.transform;
    }



    public LayerMask m_LayerMask;



    void FixedUpdate()
    {
        HandleMove();
        HandleJump();
        HandleRaycast();

    }









    private void HandleRaycast()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayLength))

        {
            ///Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            ///Debug.Log("Did Hit");

            isGrounded = true;
            


        }
        else
        {
           /// Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayLength, Color.white);
           /// Debug.Log("Did not Hit");

            isGrounded = false;
            canJump = false;
        }


    }



    public void OnMove(InputAction.CallbackContext context)
    {

        direction = context.ReadValue<Vector2>();

    }
    void HandleMove()
    {
        Vector3 move = new Vector3(direction.x * moveSpeed, 0, direction.y * moveSpeed);
        move = CameraTransform.forward * move.z + CameraTransform.right * move.x;
        move.y = 0;
        rb.AddForce((move), ForceMode.VelocityChange);
    }





    public void OnJump(InputAction.CallbackContext context)
    {

        canJump = true;

    }

    void HandleJump()
    {

        

        if (isGrounded == true && canJump == true)
        {

            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            canJump = false;

        }

    }

    public void OnMine(InputAction.CallbackContext context)
    {




        RaycastHit hit;

        if (context.performed)
        {


            gameObject.GetComponent<Grab>().OnPickup();



            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, mineRange, LayerMask.GetMask("Ore")))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 3);





                hit.collider.gameObject.GetComponent<oreLogic>().hitOre();


            }





        }

        if (context.canceled)
        {

            gameObject.GetComponent<Grab>().OnDrop();



        }

    }





}
