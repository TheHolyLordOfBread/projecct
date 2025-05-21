using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RockSpawner : MonoBehaviour
{
    public float Rock_Quantity;
    

    public Ore oreType;


    RaycastHit hit;
    public float spawnArea;
    public GameObject Rock;
    Vector3 position;
    bool canspawn = true;

    RaycastHit[] sphereHit;
    public GameObject[] badHits;
         
    private void Start()
    {
        SpawnRocks(Rock_Quantity);

    }



    void SpawnRocks(float Quantity)
    {


        for (int i = 0; i < Quantity; i++) 
        {
            
            canspawn = true;

            position = new Vector3(UnityEngine.Random.insideUnitCircle.x * spawnArea, 100, UnityEngine.Random.insideUnitCircle.y * spawnArea);

            if (Physics.Raycast(position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {

                sphereHit = Physics.SphereCastAll(hit.point, 2f, new Vector3(0.1f,0.1f,0.1f));



                if (sphereHit != null)
                {
                    for (int r = 0; r < sphereHit.Length - 1; r++)
                    {

                        for (int t = 0; t < badHits.Length - 1; t++)
                        {
                            if (sphereHit[r].rigidbody == badHits[t].gameObject.GetComponent<Rigidbody>())
                            {

                                canspawn = false;

                                Debug.Log("fucked");



                            }
                        }





                    }
                }



                if (canspawn == true)
                {

                    Instantiate(Rock, hit.point, Rock.transform.rotation);

                }
                else if (canspawn == false) 
                {
                    Debug.Log("hit object");
                    i--;
                    

                }



                Debug.DrawRay(position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow, 10f);






            }


        }

        
        
        
         

    }





}

public enum Ore { Coal, Iron, Gold }
