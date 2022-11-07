using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField, Range(0f,15f)] private float currentIntensity = 15.0f;
    [SerializeField] private ParticleSystem fireEmission = null;
    [SerializeField] float regenDelay = 2.5f;
    [SerializeField] float regenRate = .5f;
    private float startIntensity = 40.0f;
    float timeLastPutOut = 0;
    private bool isLit = true;

    private void Start()
    {
        startIntensity = fireEmission.emission.rateOverTime.constant;
    }

    private void Update()
    {
       if (isLit && currentIntensity < 10.0f && Time.time - timeLastPutOut >= regenDelay)
       {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
       }
    }
    public bool PutFireOut(float amount)
    {
        timeLastPutOut = Time.time;
        currentIntensity -= amount;
        ChangeIntensity();
       if(currentIntensity <= 0)
       {
            isLit = false;
            return true;
       }
        return false;
    }
    private void ChangeIntensity()
    {
        var emission = fireEmission.emission;
        emission.rateOverTime = currentIntensity * startIntensity; 
    }
}
