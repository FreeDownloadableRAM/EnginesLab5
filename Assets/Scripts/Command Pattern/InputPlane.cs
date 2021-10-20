using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform spherePrefab;//sphere

    //switch prefab to use
    private int prefabPicker;


    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Pick to use cube or sphere, cube is 1, sphere is anything else. press 1 on keyboard for cube, 2 for sphere.

        if (Input.GetKeyDown("1"))
        {
            //change prefabPicker to 1
            prefabPicker = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            //change prefabPicker to 1
            prefabPicker = 2;
        }
        //for cube
        if (Input.GetMouseButtonDown(0) && prefabPicker == 1)
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                ICommand command = new PlaceCubeCommand(hitInfo.point, c, cubePrefab);//creates the cube
                //ICommand command = new PlaceCubeCommand(hitInfo.point, c, spherePrefab);//creates the sphere
                CommandInvoker.AddCopmmand(command);
            }
        }
        //for sphere
        if (Input.GetMouseButtonDown(0) && prefabPicker != 1)
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                //ICommand command = new PlaceCubeCommand(hitInfo.point, c, cubePrefab);//creates the cube
                ICommand command = new PlaceCubeCommand(hitInfo.point, c, spherePrefab);//creates the sphere
                CommandInvoker.AddCopmmand(command);
            }
        }

    }
}
