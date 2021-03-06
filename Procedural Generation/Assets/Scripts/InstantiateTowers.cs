﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTowers : MonoBehaviour
{
    [Header ("Modifiers")]
    public int buildingLoops = 15;
    public int radius;
    public int maxSpaceBetweenLayer;
    [Header ("Components")]
    public GameObject tilePrefab;
    public List<GameObject> tileList = new List<GameObject>();

    public static bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        CreateBuildings(buildingLoops, 45, new Vector3(0f, 0f, 0f), radius);
    }
    private void FixedUpdate()
    {
        RotateCenter();
    }
    public void CreateBuildings(int num, int num2, Vector3 point, int radius)
    {
        for (int i = 0; i < num; i++)
        {
            radius += Random.Range(20, maxSpaceBetweenLayer);
            num2 += 1;
            for (int j = 0; j < num2; j++)
            {
                /* Distance around the circle */
                var radians = 2 * Mathf.PI / num2 * j;

                /* Get the vector direction */
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                float randomX = Random.Range(0f, 0f);
                float randomY = Random.Range(0f, 0f);
                var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY) ;

                /* Get the spawn position */
                Vector3 spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point


                /* Now spawn */
                var tile = Instantiate(tilePrefab, spawnPos, tilePrefab.transform.rotation) as GameObject;
                tile.transform.parent = this.gameObject.transform;
                tileList.Add(tile);
            }
        }
    }
    public void RotateCenter()
    {
        if(ButtonControl.rotateLeft)
        {
            this.gameObject.transform.RotateAround(this.transform.position, Vector3.up, 45 * Time.deltaTime);
            isRotating = true;
        }
        if (ButtonControl.rotateRight)
        {
            this.gameObject.transform.RotateAround(this.transform.position, Vector3.up, -45 * Time.deltaTime);
            isRotating = true;
        }
        else
        {
            this.gameObject.transform.RotateAround(this.transform.position, Vector3.up, 0);
            isRotating = false;
        }
    }
}
