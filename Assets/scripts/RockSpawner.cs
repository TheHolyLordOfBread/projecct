using System;
using System.Collections.Generic;
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
         
    private void Start()
    {
        SpawnRocks(Rock_Quantity);

    }



    void SpawnRocks(float Quantity)
    {


        for (int i = 0; i < Quantity; i++) 
        {
            position = new Vector3(UnityEngine.Random.insideUnitCircle.x * spawnArea, 100, UnityEngine.Random.insideUnitCircle.y * spawnArea);

            if (Physics.Raycast(position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {



                Debug.DrawRay(position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow, 10f);

                Instantiate(Rock, hit.point, Rock.transform.rotation);




            }


        }

        
        
        
         

    }


    



}

public enum Ore { Coal, Iron, Gold }
