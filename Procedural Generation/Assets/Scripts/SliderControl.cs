using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public BuildingGenerator buildingGenerator;
    public InstantiateTowers instantiateTowers;
    private Slider slider;
    public float minSliderValue;

    void Start()
    {
        instantiateTowers = FindObjectOfType<InstantiateTowers>();
        slider = gameObject.GetComponent<Slider>();

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
                float minSliderValue = 0;
                slider.minValue = minSliderValue;
                int listLength = g.GetComponent<BuildingGenerator>().instantiatedBlocks.Count;

                for (int i = 0; i < listLength; i ++)
                {
                    if (i > slider.value)
                    g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(false);
                    if(i < slider.value)
                        g.GetComponent<BuildingGenerator>().instantiatedBlocks[i].SetActive(true);
                }
            }
    }
}
