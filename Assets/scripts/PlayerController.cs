using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public int maxHealth = 5;
    int currentHealth;
    public int health { get {return currentHealth;}}

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    // Start is called before the first frame update
    void Start()
    {
      moveAction.Enable();
      currentHealth =  1;

     // UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
       

 
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;

        transform.position = position;
        
    }

    public void ChangeHealth (int amount)
    {    
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);


    }
   
}
