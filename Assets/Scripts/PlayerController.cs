using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    public float speed ;
    public float jump;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public float rayLength = 0.1f;
    private EventManager logic;
    public InputActionReference joystick;
    
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<EventManager>();
        
        
    }

    void Update()
    {
       // movement.x= Input.GetAxis("Horizontal")*speed * Time.deltaTime;
        movement = joystick.action.ReadValue<Vector2>() * speed * Time.deltaTime;
        movement.y = 0;
        

        if ( Input.GetKeyDown(KeyCode.Space)  )
        {
          jumping();
        }

        transform.Translate(movement,Space.Self);
        
    }

   private void OnTriggerEnter2D(Collider2D col){

        if(col.transform.tag == "Lava" ){
            logic.death();
            Debug.Log("Death called");
        }
        
    }

    public void jumping(){
          rb2d.velocity = new Vector2(0,jump);
          GetComponent<AudioSource>().Play();
    }

}