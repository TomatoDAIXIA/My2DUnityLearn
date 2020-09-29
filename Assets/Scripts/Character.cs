using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;

    private Animator animator;

    public Vector2 moveDirection;

    public Vector2 lookDirection;

    [SerializeField]
    protected bool isMove;

    private Rigidbody2D rigidbody2D;

    public bool isAttack;

    protected virtual void Start()
    {
        SetDefaultDirection();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }



    protected virtual void Update()
    {
        SetDirection();
    }

    
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 设置默认朝向
    /// </summary>
    protected virtual void SetDefaultDirection()
    {
        moveDirection = Vector2.zero;
        lookDirection = Vector2.down;
    }

    /// <summary>
    /// 设置朝向和走向
    /// </summary>
    protected abstract void SetDirection();

    public void Move()
    {
        //物理移动
        //transform.Translate(moveDirection * speed * Time.deltaTime);


        rigidbody2D.velocity = moveDirection * speed;

        //动画播放
        AnimateMovement();
    }

    /// <summary>
    /// 设置动画状态
    /// </summary>
    private void AnimateMovement()
    {
        animator.SetFloat("lookx", lookDirection.x);
        animator.SetFloat("looky", lookDirection.y);
        animator.SetFloat("movespeed", moveDirection.magnitude);
        animator.SetBool("isattack", isAttack);
    }
}
