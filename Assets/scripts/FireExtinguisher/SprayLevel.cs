using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprayLevel : MonoBehaviour
{
    [SerializeField] GameObject SprayLevelSlider;

    public void SprayLevelHeight(float newHeight)
    {
        Vector3 pos = SprayLevelSlider.transform.position;
        pos.y = newHeight;
        SprayLevelSlider.transform.position = pos;
    }

    
}
