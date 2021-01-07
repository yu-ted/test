using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D theRB2D;
    public float dashForce;
    //bla bla bla 12/31 5:43

    // Start is called before the first frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        dashForce = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
        Debug.Log(theRB2D.position.y);
        Dash();
        Teleport();
    }
    void MovePlayer()
    {
        if (canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed,
           theRB2D.velocity.y);
        }
    }

    void Jump()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && theRB2D.position.y < -3.8)
        {
            theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            theRB2D.velocity = new Vector2(dashForce, theRB2D.velocity.y);
        }
    }

    void Teleport()
    {
        Vector2 tele = new Vector2(theRB2D.position.x * -1, theRB2D.velocity.y * -1);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            theRB2D.MovePosition(tele);

        }
    }

}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D theRB2D;
    public float dashForce;
    
    //public bool grounded;
    //public LayerMask whatIsGrd;
    // public Transform grdChecker;
    //public float grdCheckerRad;

    // Start is called before the first frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;


        }
        Jump();
        // DashR();
        Teleport();
        MovePlayer();

    }

    private void FixedUpdate()
    {
        // grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);


        //Debug.Log(theRB2D.position.y);
    }

    void MovePlayer()
    {
        if(canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);

        }
    }

    void Jump()
    {
        //if (grounded == true)
        //{
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && theRB2D.position.y < -7)
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);

            }
        //}
    }
  

    void Teleport()
    {
        //if (grounded = = true)
        //{
        Vector2 center = new Vector2(0, 0);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            theRB2D.MovePosition(center);

        }
        //}
    }

}
*/
