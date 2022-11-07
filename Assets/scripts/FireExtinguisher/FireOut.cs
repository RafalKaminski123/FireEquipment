using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOut : MonoBehaviour
{
    [SerializeField] GameObject exitPoint;
    [SerializeField] private float amountExtinguishedPerSecond = .1f;
    [SerializeField] private Slider extHeight;

    private float halfPoint;

    private void Start()
    {
        halfPoint = (extHeight.maxValue - extHeight.minValue) / 6f;
    }

    private void Update()
    {
        var isBelowHalf = extHeight.maxValue - extHeight.value > halfPoint;
        
        if (Physics.Raycast(exitPoint.transform.position, exitPoint.transform.forward, out RaycastHit hit, 5f)
            && hit.collider.TryGetComponent(out FireController fire))
            fire.PutFireOut((isBelowHalf ?  amountExtinguishedPerSecond : amountExtinguishedPerSecond * 0.5f) * Time.deltaTime);

    }
}
