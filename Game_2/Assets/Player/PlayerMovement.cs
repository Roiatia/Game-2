using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float Speed = 8f;
    [SerializeField] private float jump = 5f;
    [SerializeField] private float playerScale = 1.5f;

    //private Animator animator;


    private Rigidbody2D rb2d;
    private Vector2 input;
    private bool isGrounded = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(input.x * Speed, rb2d.linearVelocity.y);
        //animator.SetFloat("Speed", Mathf.Abs(input.x));
    }


    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();

        //animator.SetFloat("Speed", Mathf.Abs(input.x));

        if (input.x < 0)
        {
            transform.localScale = new Vector3(-playerScale, playerScale, 1);
        }
        else if (input.x > 0)
        {
            transform.localScale = new Vector3(playerScale, playerScale, 1);
        }
    }


    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            rb2d.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        
            isGrounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
