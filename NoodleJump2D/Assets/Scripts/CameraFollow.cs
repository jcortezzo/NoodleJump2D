using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;

    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        maxHeight = Mathf.Max(target.position.y, maxHeight);
        this.transform.position = new Vector3(this.transform.position.x + offset.x, 
                                              maxHeight + offset.y, 
                                              this.transform.position.z);
    }
}
