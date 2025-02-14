using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

/*
COMMENT KEY

- A "--" In front of a 'question' or task means that the mentioned task was/is completed

*/

public class LabWeek6 : MonoBehaviour
{
    // Start is called before the first frame update
    // Variable initiation
    public int sizeOfForest;
    public int stonesrequired;
    public GameObject[] tress;
    public GameObject[] stones;

    public float min = -5.0f;
    public float max = 5.0f;
    public float scaleMin = 0.1f;
    public float scaleMax = 3.0f;



    // Creates plane
    void CreatePlan()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;

        plane.transform.localScale = new Vector3(2, 2, 2);

        // -- Possibly smaller?
    }

    void CreateForest() // CreateForest Function
    {

        sizeOfForest = Random.Range(10, 50); // Assigns a random value between 10 and 50 to 'sizeOfForest'

        for (int i = 1; i < sizeOfForest; i++) // Create variable 'i' / If 'i' is less than 'sizeOfForest' block runs / increment 'i' every time block is run
        {
            if (i % 2 == 0) // If statement checks to see if 2 divides into 'i' evenly. If so, a green cyclinder is created
            {
                GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // Create cylinder

                Renderer renderer = cylinder.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard")); // Use "Standard" material
                renderer.material.color = Color.green; // Change cylinder color to green

                cylinder.transform.position = new Vector3(Random.Range(min, -1.0f), Random.Range(0, max), Random.Range(min, max)); // Position Randomizer (Spawns on -x axis of plane)
                cylinder.transform.localScale = new Vector3(Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax)); // Scale Randomizer
                //Debug.Log("Green Object Created" + i); // Log Green Object creation and # of cylinders
            }
            else // If 2 doesn't divid into 'i' evenly, then a blue cyclinder is created.
            {
                GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // Create cylinder

                Renderer renderer = cylinder.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard")); // Use "Standard" material
                renderer.material.color = Color.blue; // Change cylinder color to blue

                cylinder.transform.position = new Vector3(Random.Range(min, -1.0f), Random.Range(0, max), Random.Range(min, max)); // Position Randomizer (Spawns on -x axis of plane)
                cylinder.transform.localScale = new Vector3(Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax)); // Scale Randomizer
                //Debug.Log("Blue Object Created" + i); // Log Blue Object creation and # of cylinders
            }

            /*
               -- We need to alternate between colors 
               -- Change sizes and postions
               -- Spawns Random number of objects
               -- Spawn on 1 side of plane
            */
        }

       
    }


    void CreatePyramid() //Create Pyramid Function
    {
        // JUST DO IT!
        float x = 1.0f; 
        int y = 1;
        float z = 1.0f;
        float I = 5; // Number of levels

        Dictionary<float, Color> colorMap = new Dictionary<float, Color> // ColorMap Dictionary to assign each level a different color
        {
            {1, Color.red},
            {2, Color.green},
            {3, Color.blue},
            {4, Color.magenta},
            {5, Color.cyan},
        };

        for (float i = I; I != 0; I--)
        {
            float Z = z; // Placeholder 'z' variable
            while (i != 0) // Makes the printing of 5 blocks in a row print again 5 times
            {
                
                float X = x; // Placeholder 'x' variable
                for (float ii = I; ii != 0; ii--) // Makes (whatever value of 'I') blocks print in a row
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create cube

                    Renderer renderer = cube.GetComponent<Renderer>();
                    renderer.material = new Material(Shader.Find("Standard")); // Use "Standard" material
                    
                    if (colorMap.TryGetValue(I, out Color newColor)) // Assigns color based on level of Pyramid / Protected by "TryGetValue" / outputs a struct of 'Color'
                        {
                        renderer.material.color =  newColor; // Change color
                        }
                        

                    cube.transform.position = new Vector3(x, y, z); // Change position based on variable (x, y, z) values
                    cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); // Scale cube to (0.9f x 0.9f x 0.9f)
                    x++; // Increment 'x' in order for next cube to spawn beside it on the x-axis
                    // Debug.Log("Cube Object Created");
                }
                i--; // Increment 'i' down (Counter)
                z++; // Increment 'z' (z-axis placement)
                x = X; // Reset 'x' value
            }
            z = Z; // Reset 'z' value

            i = (I -1); // Sets 'i' equal to 'I'
            x += 0.5f; // Increment 'x' by .5
            z += 0.5f; // Increment 'z' by .5
            y++; // Increment 'y'
            Debug.Log("Times ran though: " + I + ", y-level = " + (y - 1));
        }
    /*
        for (int i = 5; i != 0; i--,z++) // Makes the printing of 5 blocks in a row print again 5 times
        {

            for (int ii = 5; ii != 0; ii--) // Makes 5 blocks print in a row
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create cube

                Renderer renderer = cube.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard")); // Use "Standard" material
                renderer.material.color = Color.cyan; // Change color Cyan

                cube.transform.position = new Vector3(x, y, z); // Change position based on variable (x, y, z) values
                cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); // Scale cube to (0.9f x 0.9f x 0.9f)
                x++; // Increment 'x' in order for next cube to spawn beside it on the x-axis
                Debug.Log("Cube Object Created");
            }
            x = 1; // Reset 'x' value
        }

    */


    }
   
    void Start()
    {
        CreatePlan();
        CreateForest();
        CreatePyramid();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
