using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float speed;
    private Rigidbody2D rb;
    private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float minX = cam.transform.position.x - width / 2f;
        float maxX = cam.transform.position.x + width / 2f;
        float minY = cam.transform.position.y - height / 2f;
        float maxY = cam.transform.position.y + height / 2f;

        if (transform.position.x < minX || transform.position.x > maxX ||
            transform.position.y < minY || transform.position.y > maxY)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void Shoot(Vector2 vel)
    {
        rb.velocity = vel;
    }
}
