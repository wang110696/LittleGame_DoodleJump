using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sensitive = 10f;


    private void Update()
    {
        PlayerController();
        //查看越界
        checkOverEdge();
    }

    private void checkOverEdge()
    {
        if (transform.position.x < -6f)
        {
            transform.position = new Vector2(6f, transform.position.y);
        }
        if (transform.position.x > 6f)
        {
            transform.position = new Vector2(-6f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //下落的时候才计算碰撞。不然角色只要碰到东西就会往上飞
        if (rb.velocity.y <= 0)
        {
            if (col.CompareTag("board"))
            {
                rb.velocity = new Vector2(0f, 10f);
            }
        }

        if (col.CompareTag("win"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void PlayerController()
    {
        float horizontalAxis = 0;
        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        rb.velocity = new Vector2(horizontalAxis * sensitive, rb.velocity.y);
    }
}