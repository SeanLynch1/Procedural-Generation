using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    #region Fields

    [Header("Ints")]
    public int maxBuildingHeight;
    public int minBuildingHeight;
    private int buildingHeight;
    [Header ("Floats")]
    public float blockSpacing = 5;

    [Header("Game Objects")]
    private GameObject tileGenerator;

    [Header("Lists")]
    public List<GameObject> buildingBlockPrefabs;
    private List<GameObject> instantiatedBlocks = new List<GameObject>();
    #endregion
    void Start()
    {
        tileGenerator = GameObject.Find("Tile Generator");
        tileGenerator.SetActive(false);
        AssignBuildingHeights();
        BuildTower();
    }

    // Update is called once per frame
    void Update()
    {
        ModifyTower();
    }
    public void AssignBuildingHeights()
    {
        if (minBuildingHeight < 1)
            minBuildingHeight = 1;
        buildingHeight = Random.Range(minBuildingHeight, maxBuildingHeight);
    }
    public Vector3 buildingBlockPosition;
    public void BuildTower()
    {
        float increasableValue = 0;
        for (int i = 0; i < buildingHeight; i++)
        {
            if (i != 0)
                increasableValue += blockSpacing * buildingBlockPrefabs.Count;
            for (int j = 0; j < buildingBlockPrefabs.Count; j++)
            {
                 buildingBlockPosition = new Vector3(this.transform.position.x, j * blockSpacing + increasableValue, this.transform.position.z);
                GameObject buildingBlock = Instantiate(buildingBlockPrefabs[Random.Range(0, buildingBlockPrefabs.Count)], buildingBlockPosition, Quaternion.identity);
                buildingBlock.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // HSV = shade and intensity values
                instantiatedBlocks.Add(buildingBlock);
            }
        }
    }
    public Vector3 buildingBlockPosition2;
    public void ModifyTower()
    {
        float increasableValue = 0;
        foreach(GameObject g in instantiatedBlocks)
        {
            for (int i = 0; i < buildingHeight; i++)
            {
                    increasableValue += (blockSpacing * buildingBlockPrefabs.Count / instantiatedBlocks.Count);
               
                for (int j = 0; j < buildingBlockPrefabs.Count; j++)
                {
                         buildingBlockPosition2 = new Vector3(this.transform.position.x,(j * blockSpacing + increasableValue) - (blockSpacing * j) - blockSpacing , this.transform.position.z);
                    g.transform.position = buildingBlockPosition2;
                }
            }
        }
    }
}
