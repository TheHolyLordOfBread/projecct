using UnityEngine;

public class HandPos : MonoBehaviour
{
    public float handRange;
    public LayerMask everything;

    void Update()
    {
        RaycastHit hit;


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, handRange, everything))
        {




            gameObject.GetComponent<Rigidbody>().position = hit.point;



        }
        else
        {


            gameObject.GetComponent<Rigidbody>().position = Camera.main.transform.position + Camera.main.transform.TransformDirection(Vector3.forward) * handRange;


        }



    }
}
