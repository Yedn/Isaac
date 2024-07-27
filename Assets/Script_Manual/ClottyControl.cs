using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClottyControl : MonoBehaviour
{
    
    public enum State {Idle,Active,Die};
    public State state;
    public Rigidbody2D _rigid;
    public float MaxHp = 6.0f;
    public float CurrentHp;

    [Header("MoveControl")]
    public int RundomNum;
    public float RestTime;


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
            Debug.Log("Clotty Has Died");
            state = State.Die;
            Destroy(this);
        }
    }

    public void CanActive()
    {
        state = State.Active;
    }

    public void RandomMove()
    {
        int xMove = 
    }

    private void OnTriggerEnter2D(Collider2D collision)//±»¹¥»÷
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _rigid.AddForce(collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized, ForceMode2D.Impulse);
            CurrentHp -= 1.0f;
            //Debug.Log("Clotty be Hit");
        }
    }
}
