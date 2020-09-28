using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private const float JUMP_EPSILON = 0.1f;
    //[SerializeField] private float jumpForce;
    
    private Rigidbody2D rb;
    private Camera camera;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWrap();
    }

    void ScreenWrap()
    {
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        float minBound = camera.transform.position.x - width / 2f;
        float maxBound = camera.transform.position.x + width / 2f;
        if (transform.position.x > maxBound)
        {
            transform.position = new Vector2(minBound, transform.position.y);
        }
        else if (transform.position.x < minBound)
        {
            transform.position = new Vector2(maxBound, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }


    public void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //anim.Update(0);
        //anim.
        anim.Play("bounce", 1);
    }

    public bool IsAscending()
    {
        return rb.velocity.y > JUMP_EPSILON;
    }
}
