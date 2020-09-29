using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;


    private float initHealth = 100;
    private float initMana = 100;

    private SpellBook spellBook;

    /// <summary>
    /// 法术出口点 注释修改
    /// </summary>
    [SerializeField]
    private Transform[] exitList;

    /// <summary>
    /// 四方向序号：上下左右  0123
    /// </summary>
    private int direcIndex = 1;

    public Transform MyTarget { get; set; }

    /// <summary>
    /// 四方向遮挡物
    /// </summary>
    [SerializeField]
    private Block[] myBlocks;

    protected override void Start()
    {
        health.Initialized(initHealth, initHealth);
        mana.Initialized(initMana, initMana);
        spellBook = GetComponent<SpellBook>();
        base.Start();
    }

    protected override void Update()
    {
        BlockManager();
        base.Update();
    }

    /// <summary>
    /// 设置方向相关
    /// </summary>
    protected override void SetDirection()
    {
        //以下代码仅仅用来调试
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                health.MyCurrentValue -= 10;
                mana.MyCurrentValue -= 10;
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                health.MyCurrentValue += 10;
                mana.MyCurrentValue += 10;
            }
        }

        //默认不动
        moveDirection = Vector2.zero;
        isMove = false;

        if (isAttack)
            return;

        if (Input.GetKey(KeyCode.A))
        {
            direcIndex = 2;
            moveDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direcIndex = 3;
            moveDirection = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            direcIndex = 0;
            moveDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direcIndex = 1;
            moveDirection = Vector2.down;
        }

        //如果有方向输入，改变朝向
        if (moveDirection.magnitude > 0)
        {
            isMove = true;
            lookDirection = moveDirection;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    private IEnumerator Attack(int spellIndex)
    {
        Spell s = spellBook.CastSpell(spellIndex);

        Debug.Log("携程2");
        isAttack = true;
        yield return new WaitForSeconds(s.MyCasttime);
        isAttack = false;
        Debug.Log("携程3");


        var spellObj =  Instantiate(s.MySpellPrefab, exitList[direcIndex].position, Quaternion.identity);
        var spell = spellObj.GetComponent<SpellScript>();
        spell.Mytarget = MyTarget;
    }

    /// <summary>
    /// 创建子弹
    /// </summary>
    public void CastSpell(int spellIndex)
    {

        if (MyTarget == null || !InLineOfSight() || isAttack == true)
            return;
        Debug.Log("携程1");
        StartCoroutine(Attack(spellIndex));
        Debug.Log("携程4");

    }

    /// <summary>
    /// 管理遮挡物
    /// </summary>
    private void BlockManager()
    {
        foreach (var item in myBlocks)
        {
            item.SetBlockActive(true);
        }

        myBlocks[direcIndex].SetBlockActive(false);
    }

    /// <summary>
    /// 视线检测
    /// </summary>
    /// <returns></returns>
    private bool InLineOfSight()
    {
        Vector3 targetDirec = (MyTarget.position - transform.position).normalized;
        //Debug.DrawRay(transform.position, targetDirec,Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirec, Vector2.Distance(MyTarget.position, transform.position), LayerMask.GetMask("Blocks"));
        if (hit.collider == null)
        {
            return true;
        }

        Debug.Log(hit.collider.name);

        return false;
    }

   
}
