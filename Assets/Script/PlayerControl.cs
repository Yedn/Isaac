using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Bullet;
    private SpriteRenderer SR;
    public Rigidbody2D rb;
    private Animator _Animator;
    private Transform m_Transform;

    public float speed = 3.0f;
    public float cooltime = 1.0f;
    
    public float x=0;
    public float y=0;


    void Move(float x,float y)
    {
        //改变物体速度
        rb.velocity = new Vector2(x * speed, y*speed);
    }
    void Flip(float x)
    {
        if (x < 0)
        {
            SR.flipX = true;
            //BodyisRight = false;
        }

        if (x > 0)
        {
            SR.flipX = false;
            //BodyisRight = true;
        }
    }
    void shoot()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject bulletObj = Instantiate(Bullet);
                bulletObj.transform.position = transform.position;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetDirection(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject bulletObj = Instantiate(Bullet);
                bulletObj.transform.position = transform.position;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetDirection(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                GameObject bulletObj = Instantiate(Bullet);
                bulletObj.transform.position = transform.position;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetDirection(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                GameObject bulletObj = Instantiate(Bullet);
                bulletObj.transform.position = transform.position;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.SetDirection(Vector2.left);
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
        m_Transform = this.transform;
    }

    void BodyMove()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            m_Transform.localRotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = new Vector2(-speed, speed);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            m_Transform.localRotation = Quaternion.Euler(0, 90, 0);
            rb.velocity = new Vector2(speed, speed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            m_Transform.localRotation = Quaternion.Euler(0, -90, 0);
            rb.velocity = new Vector2(-speed, -speed);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            m_Transform.localRotation = Quaternion.Euler(0, 90, 0);
            rb.velocity = new Vector2(speed, -speed);
        }
        else
        {	//单独对四个正方向最后进行检测
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_Transform.localRotation = Quaternion.Euler(0, -90, 0);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_Transform.localRotation = Quaternion.Euler(0, 90, 0);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
}

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxisRaw("Horizontal_Player");
        x = Input.GetAxisRaw("Vertical_Player");
        Move(x,y);
        //BodyMove();
        //Flip(x);
        shoot();
    }
}
