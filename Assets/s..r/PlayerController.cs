using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public int maxHealth = 5;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
      moveAction.Enable();
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Debug.Log(move);

 
        Vector2 position = (Vector2)transform.position + move * 0.3f * Time.deltaTime;

        transform.position = position;
        
    }

    void ChangeHealth (int amount)
    {    
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

    }
   
}
