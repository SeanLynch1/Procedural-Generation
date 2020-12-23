using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    InstantiateTowers instantiateTowers;
    private Slider slider;
    private float minSliderValue;
    // Start is called before the first frame update
    void Start()
    {
        instantiateTowers = FindObjectOfType<InstantiateTowers>();
        slider = gameObject.GetComponent<Slider>();

        foreach (GameObject g in instantiateTowers.tileList)
        {
            minSliderValue = g.GetComponent<BuildingGenerator>().blockSpacing;
            slider.minValue = minSliderValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBlockSpacing()
    {
        foreach (GameObject g in instantiateTowers.tileList)
        {
            g.GetComponent<BuildingGenerator>().blockSpacing = slider.value;
        }
    }
}
