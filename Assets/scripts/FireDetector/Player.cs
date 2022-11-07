using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private TextMeshProUGUI temperatureText;

    private string hot = "Temperature = 1000C";
    private string cold = "Temperature = -100C";

    private void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * movementSpeed;

        characterController.Move(playerMovement);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hot")
        {
            temperatureText.text = hot;
        }
        else 
        {
            temperatureText.text = cold;
        }
    }

   






}
