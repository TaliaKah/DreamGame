using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxAnimation : MonoBehaviour
{
  private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example: Trigger the "Run" animation when the player presses a key
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Entry", true);
        }
        else
        {
            animator.SetBool("Entry", false);
        }

        // Add more logic to control other animations as needed
    }
}
