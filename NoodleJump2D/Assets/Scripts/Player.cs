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

    public bool IsDead { get; private set; }
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

        float minXBound = camera.transform.position.x - width / 2f;
        float maxXBound = camera.transform.position.x + width / 2f;

        float minY = camera.transform.position.y - height / 2f;

        if (transform.position.x > maxXBound)
        {
            transform.position = new Vector2(minXBound, transform.position.y);
        }
        else if (transform.position.x < minXBound)
        {
            transform.position = new Vector2(maxXBound, transform.position.y);
        }

        if (transform.position.y < minY) Die();
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

        anim.Play("bounce", 1, 0f);
    }

    public bool IsAscending()
    {
        return rb.velocity.y > JUMP_EPSILON;
    }

    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        speed = 0;
        IsDead = true;
    }
}
