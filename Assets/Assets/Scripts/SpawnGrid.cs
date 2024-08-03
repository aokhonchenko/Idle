using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{

    private SpawningObject nowSpawn;
    private Camera mainCamera;


    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowSpawn != null) 
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (groundPlane.Raycast(ray, out float position)) {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int z = Mathf.RoundToInt(worldPosition.z);

                nowSpawn.transform.position = new Vector3(x, 0, z);

                if (Input.GetMouseButtonDown(0)) {
                    SpawningObject tmp = null;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Debug.Log("Left Shift key is being pressed");
                        tmp = Instantiate(nowSpawn);
                    }
                    nowSpawn = tmp;
                }

                
            }


        }
    }

    public void StartPlace(SpawningObject spawningObject) {
        if (nowSpawn != null) {
            Destroy(nowSpawn.gameObject);
        }
        nowSpawn = Instantiate(spawningObject);
    }
}
