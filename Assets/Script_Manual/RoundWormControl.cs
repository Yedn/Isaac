using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundWormControl : MonoBehaviour
{
    public GameObject RoundWorm;
    public GameObject sliceKey;

    public Room inWhichRoom;
    public bool created=false;
    public enum State { Idle, Active, Die };
    public State state;
    public Rigidbody2D _rigid;
    public float MaxHp = 4.0f;
    public float CurrentHp;
    public Animator headanima;
    public Animator bodyanima;
    public bool CanBeAttacked = true;

    public SpriteRenderer sr;
    public Color StartColor;
    private enum Direction { up, down, left, right };
    private Direction direction;
    private float act_frequency = 2.0f;
    private float invoketime = 0.0f;
    public GameObject enemybullet;
    public float speed = 2.0f;
    public float EnemyBullet_Speed = 5.0f;
    public bool randomActive = false;//false¡ª¡ª×ß true¡ª¡ª¹¥»÷

    public GameObject Head;
    public GameObject Body;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        CurrentHp = MaxHp;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp <= 0.0f)
        {
            //Debug.Log("RoundWorm Has Died");
            state = State.Die;
            RoundWorm.SetActive(false);
            if (created == false)
            {
                Instantiate(sliceKey, transform.position, Quaternion.identity);
                created = true;
            }
            
            inWhichRoom.EnemyNum -= 1;
        }

        if (state == State.Active)
        {
            invoketime += Time.deltaTime;
            if (invoketime > act_frequency)
            {
                invoketime = 0f;
                if (randomActive == true)
                {
                    RandomAttack();
                }
                else
                {
                    RandomMove();
                }
                randomActive = !randomActive;
            }
        }
    }


    public void CanActive()
    {
        state = State.Active;
    }

    public void RandomMove()
    {
        CanBeAttacked = false;
        //headanima.SetTrigger("GoDown");
        headanima.SetBool("UpToDown", true);
        headanima.SetBool("DownToUp", false);
        InvokeMove();
    }
     
    public void InvokeMove()
    {
        direction = (Direction)UnityEngine.Random.Range(0, 4);
        switch (direction)
        {
            case Direction.up:
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + new Vector3(0f, 1f, 0f) , speed*Time.deltaTime);
                gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 1f, 0f);
                //CanBeAttacked = true;
                break;
            case Direction.down:
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + new Vector3(0f, -1f, 0f), speed * Time.deltaTime);
                gameObject.transform.position = gameObject.transform.position + new Vector3(0f, -1f, 0f);
                //CanBeAttacked = true;
                break;
            case Direction.left:
                gameObject.transform.position = gameObject.transform.position + new Vector3(-1f, 0f, 0f);
                //CanBeAttacked = true;
                break;
            case Direction.right:
                gameObject.transform.position = gameObject.transform.position + new Vector3(1f, 0f, 0f);
                //CanBeAttacked = true;
                break;
        }
        //headanima.SetTrigger("GoUp"); 
        headanima.SetBool("UpToDown", false);
        headanima.SetBool("DownToUp", true);
        CanBeAttacked = true;
    }

    public void RandomAttack()
    {
        Vector3 targetdir = (GameObject.FindWithTag("Player").transform.position - gameObject.transform.position).normalized* EnemyBullet_Speed;
        GameObject bullet = Instantiate(enemybullet, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBulletControl>().SetSpeed(targetdir);
    }

    private void OnTriggerEnter2D(Collider2D collision)//±»¹¥»÷
    {
        if (collision.gameObject.CompareTag("Bullet") && CanBeAttacked==true)
        {
            Destroy(collision.gameObject);
            _rigid.AddForce(collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized, ForceMode2D.Impulse);
            CurrentHp -= 1.0f;
            HitColor();
        }
    }

    public void HitColor()
    {
        sr.color = Color.red;
        Invoke("ResetColor", 0.1f);
    }

    public void ResetColor()
    {
        sr.color = StartColor;
    }
}
