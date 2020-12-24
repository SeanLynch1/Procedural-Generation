using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public BuildingGenerator buildingGenerator = null;
    public InstantiateTowers instantiateTowers;
    private FractalGeneration fractalGeneration;
    private Slider slider;
    public static int sideBlocks = 0;
    public static bool changeScale;
    public float minSliderValue;

    void Start()
    {
        instantiateTowers = FindObjectOfType<InstantiateTowers>();
        slider = gameObject.GetComponent<Slider>();
        if (buildingGenerator != null)
        minSliderValue = buildingGenerator.blockSpacing;
        slider.minValue = minSliderValue;
    }

    public void ChangeBlockSpacing()
    {
        if (instantiateTowers != null)
            foreach (GameObject g in instantiateTowers.tileList)
            {
                g.GetComponent<BuildingGenerator>().blockSpacing = slider.value;
            }
    }
    public void BlockActivity()
    {
        if (instantiateTowers != null)
            foreach (GameObject g in instantiateTowers.tileList)
            {
                fractalGeneration = g.GetComponentInChildren<FractalGeneration>();
                if (fractalGeneration != null)
                {
                    slider.maxValue = (instantiateTowers.tileList.Count - fractalGeneration.trackOfBlocks.Count) / 3.5f;
                }
                    float minSliderValue = 0;
                    slider.minValue = minSliderValue;
                    int listLength = g.GetComponent<BuildingGenerator>().instantiatedBlocks.Count;

                    for (int i = 0; i < listLength; i++)
                    {
                        if (i > slider.value)
                            g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(false);
                        if (i < slider.value)
                            g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(true);
                    }
            }
    }
   
}
