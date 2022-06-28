using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator theAnim;
    public float playerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            theAnim.SetFloat("HorizontalMove", Input.GetAxisRaw("Horizontal"));
            theAnim.SetFloat("VerticalMove", 0f);     
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f) * playerSpeed;
        }

        if(Input.GetAxisRaw("Vertical") != 0)
        {
            theAnim.SetFloat("VerticalMove", Input.GetAxisRaw("Vertical"));
            theAnim.SetFloat("HorizontalMove", 0f);               
            theRB.velocity = new Vector2(0f, Input.GetAxisRaw("Vertical")) * playerSpeed;            
        }

        if(Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerSpeed * .7f;   
        }

        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            theRB.velocity = new Vector2(0, 0);  
        }

    }
}
