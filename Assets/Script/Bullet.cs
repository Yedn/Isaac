using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 15f;
    public float LiveTime = 3f;

    private Vector2 _Direction;
    private float _HasLiveTime = 0;

    private void Update()
    {
        _HasLiveTime += Time.deltaTime;
        if (_HasLiveTime > LiveTime)
        {
            Destroy(gameObject);
        }

        transform.Translate(_Direction * (Speed * Time.deltaTime));
    }

    public void SetDirection(Vector2 dir)
    {
        _Direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Env"))
        {
            Destroy(gameObject);
        }
    }
}
