using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed;


    public Transform Mytarget;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Mytarget == null)
            return;

        Debug.Log("spell move");

        Vector2 direction = Mytarget.position - transform.position;
        rigidbody2D.velocity = direction.normalized * speed;

        //旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBox" && collision.transform == Mytarget)
        {
            GetComponent<Animator>().SetBool("impact", true);
            rigidbody2D.velocity = Vector2.zero;
            Mytarget = null;
        }
    }
}
