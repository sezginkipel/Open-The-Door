using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    
    public bool hasKey = false;

    private Rigidbody2D _playerRb;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }
    
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        _playerRb.AddForce(new Vector2((horizontalInput * speed) * Time.deltaTime, (verticalInput * jumpForce) * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D triggerObject)
    {
        if (triggerObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(triggerObject.gameObject);
        }
        
        if (triggerObject.CompareTag("Door"))
        {
            if (hasKey)
            {
                Destroy(triggerObject.gameObject);
                Debug.Log("You Win!");
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }else
            {
                Debug.Log("You need a key to open this door!");
            }
        }
        
    }
}
