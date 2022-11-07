using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class PowderLevel : MonoBehaviour
{
    public const float MAX_LEVEL = 11f;
    [SerializeField] private Slider powderLevel;
    [SerializeField] GameObject spray;
    public float Fillspeed = 0.5f;

    public bool isButtonHeld = false;
    private float startTime;
    private float maxDuration = 5f;
    private float realDuration = -1;
    private float delta = -1;
    private float startLevel = -1;
  
    
    private void Awake()
    {
        powderLevel = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        powderLevel.value = MAX_LEVEL;
    }

    void Update()
    {
        SprayPowder();
        RegeneratePowderLevel();
    }

    public void SprayPowder()
    {
        if (!isButtonHeld)
            return;
        
        if (powderLevel.value <= MAX_LEVEL)
            powderLevel.value -= Fillspeed * Time.deltaTime;

       if (powderLevel.value == 0)
        {
            spray.SetActive(false);
        }
    }

    public void StartRegeneration()
    {
        startTime = Time.time;
        delta = MAX_LEVEL - powderLevel.value;
        startLevel = powderLevel.value;
        realDuration = (maxDuration * delta) / MAX_LEVEL;
    }

    private void RegeneratePowderLevel()
    {
        if (isButtonHeld || powderLevel.value >= MAX_LEVEL)
            return;
        
        var t = (Time.time - startTime) / realDuration;
        powderLevel.value = Mathf.Lerp(startLevel, MAX_LEVEL, t);
    }
}
