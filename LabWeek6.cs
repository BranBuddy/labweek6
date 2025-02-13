using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabWeek6 : MonoBehaviour
{
    // Start is called before the first frame update

    public int sizeOfForest;
    public int stonesrequired;
    public GameObject[] tress;
    public GameObject[] stones;

    public int min = -3;
    public int max = 0;
    public float scaleMin = 0.1f;
    public float scaleMax = 1.0f;



    // Creates plane
    void CreatePlan()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;

        plane.transform.localScale = new Vector3(10,10,10);

        // Possibly smaller?
    }

    void CreateForest()
    {
        for (int i = 1; i < sizeOfForest; i++)
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            Renderer renderer = cylinder.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Standard"));
            renderer.material.color = Color.green;

            cylinder.transform.position = new Vector3(Random.Range(min, max), Random.Range(0, max), Random.Range(min, max));
            cylinder.transform.localScale = new Vector3(Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax));
            

            Debug.Log("Object Created" + i);

            /*
                We need to alternate between colors
                Change sizes and postions
                Spawns Random number of objects
                Spawn on 1 side of plan
            */
        }

       
    }


    void CreatePyramid()
    {
        // JUST DO IT!
    }
   
    void Start()
    {
        CreatePlan();
        CreateForest();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
