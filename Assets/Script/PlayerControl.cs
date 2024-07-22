using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 3.0f;
    public float x=0;
    public float y=0;
    public void Move(float x,float y)
    {
        //改变物体速度
        rb.velocity = new Vector2(x * speed, y*speed);
    }
    public void shoot()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxisRaw("Horizontal_Player");
        x = Input.GetAxisRaw("Vertical_Player");
        Move(x,y);
    }
}
