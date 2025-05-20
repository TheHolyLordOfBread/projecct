using UnityEngine;
using UnityEngine.UIElements;

public class OreSpawner : MonoBehaviour
{

    public int oreQuantity;
    RaycastHit hit;
    public GameObject Ore;
    Vector3 position;

    float rocksToSpawn;

    private void Awake()
    {
        rocksToSpawn = oreQuantity;

        Debug.Log("Ore quantity has been set");
    }



    private void Update()
    {
        if (rocksToSpawn > 0)
        {



            
            position = transform.position;
            position = position + new Vector3(Random.Range(-1f,1.1f), 10, Random.Range(-1f, 1.1f));

            if (Physics.Raycast(position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity,LayerMask.GetMask("Rock")))
            {


                Debug.Log("spawned Ore");
                Debug.DrawRay(position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow, 10f);

                Instantiate(Ore, hit.point, Quaternion.LookRotation(hit.normal));





                rocksToSpawn--;



            }
        }
    }

}


        
