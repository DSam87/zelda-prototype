using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public string isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && isMoving == "reset")
        {
            isMoving = "Horizontal";
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else if(Input.GetAxisRaw("Vertical") != 0 && (isMoving == "reset" || isMoving == "Vertical"))
        {
            isMoving = "Vertical";
            theRB.velocity = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            theRB.velocity = new Vector2(0f, 0f);
            isMoving = "reset";
        }
    }
}
