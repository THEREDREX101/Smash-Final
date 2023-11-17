using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{    
    public LayerMask layermask;    

    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private CapsuleCollider2D boxCol;
    private float Horizontal;

    public bool isGrounded = false;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {

        Raycasting();
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        

        
    }

    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
        
    }


    private void FixedUpdate(){

        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    void Raycasting(){
        Vector3 origin = boxCol.bounds.center;
        Vector3 size = boxCol.bounds.size;

        size.y = 0f;

        bool ground_hit = Physics2D.Raycast(origin, Vector2.down, boxCol.bounds.size.y + 0.1f, layermask);

        if(ground_hit){
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }




}
