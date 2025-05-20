using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Grab : MonoBehaviour
{





    /// <summary>
    /// 
    ///     1.try accelerating the game object towards the hand position 
    ///     2.make other ores spawn
    ///     3.make so ores can't spawn too close to each other/on players
    ///     4.add shop (ore rarity / movespeed / mining strength)
    ///     5.new days (reset ores)
    ///     6.Minecart and rails
    ///     7. ores have weight
    ///     8. environment
    ///     9. sound effects / VFX
    ///     10. fix player movement
    ///     11. flashlight
    ///     12. energy
    ///     13. mining uses energy
    ///     14. monster scared of light
    /// 
    /// </summary>











    GameObject heldOre;
    public float heldDistance;  
    float Distance;
    bool holding;

    [SerializeField] LayerMask notOre;


    public void FixedUpdate()
    {

        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, heldDistance, notOre);


        Distance = hit.distance;

        


        if (holding == true && heldOre != null)
        {
            heldOre.GetComponent<Rigidbody>().useGravity = false;
            heldOre.GetComponent<Rigidbody>().position = Camera.main.transform.position + Camera.main.transform.TransformDirection(Vector3.forward) * (hit.collider != null ? Distance :  heldDistance - 0.2f);

            heldOre.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            heldOre.GetComponent<Rigidbody>().linearVelocity = new Vector3(0,0,0);


        }
        else if (holding == false && heldOre != null)
        {

            heldOre.GetComponent<Rigidbody>().useGravity = true;


        }

    }



    public void OnPickup()
    {



        RaycastHit hit;

        
        
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 3f, LayerMask.GetMask("DroppedOre")))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 3);


                heldOre = hit.collider.gameObject;
                 holding = true;

                 


            }





        

    }
    public void OnDrop()
    {




        holding = false;






    }














    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.GetChild(2).position, 5);
    }

}