using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Animator theAnim;
    public float playerSpeed;

    public float movementCountDown;
    public float countDownDuration;

    public static PlayerController instance;

    public string areaTransitionName;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
            theRB = GetComponent<Rigidbody2D>();
            theAnim = GetComponent<Animator>();
            movementCountDown = 0;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(movementCountDown <= 0)
        {
            theRB.velocity = new Vector2(0, 0);  
            movementCountDown = countDownDuration;

            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    if(Input.GetAxisRaw("Vertical") == 0)
                    {
                        theAnim.SetFloat("lastPosition", 1);
                    }
                    else
                    {
                        if(Input.GetAxisRaw("Vertical") > 0)
                        {
                            theAnim.SetFloat("lastPosition", 0);
                        }
                        else
                        {
                            theAnim.SetFloat("lastPosition", 2);
                        }
                    }
                }
                else
                {
                    if(Input.GetAxisRaw("Vertical") == 0)
                    {
                        theAnim.SetFloat("lastPosition", 3);
                    }
                }
                theAnim.SetFloat("HorizontalMove", Input.GetAxisRaw("Horizontal"));
                theAnim.SetFloat("VerticalMove", 0f);
                theAnim.SetBool("isMoving", true);
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f) * playerSpeed;
            }

            if(Input.GetAxisRaw("Vertical") != 0)
            {
                if(Input.GetAxisRaw("Vertical") > 0)
                {
                    theAnim.SetFloat("lastPosition", 0);
                }
                else
                {
                    theAnim.SetFloat("lastPosition", 2);
                }
                theAnim.SetFloat("VerticalMove", Input.GetAxisRaw("Vertical"));
                theAnim.SetFloat("HorizontalMove", 0f);        
                theAnim.SetBool("isMoving", true);       
                theRB.velocity = new Vector2(0f, Input.GetAxisRaw("Vertical")) * playerSpeed;            
            }

            if(Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0)
            {

                if(Input.GetAxisRaw("Vertical") > 0)
                {
                    theAnim.SetFloat("lastPosition", 0);
                }
                else
                {
                    theAnim.SetFloat("lastPosition", 2);
                }
                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerSpeed * .7f;   
                theAnim.SetBool("isMoving", true);
            }

            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                theRB.velocity = new Vector2(0, 0);  
                theAnim.SetBool("isMoving", false);
            }
        }
        else
        {
           movementCountDown -= Time.deltaTime;
        }

    }


}
