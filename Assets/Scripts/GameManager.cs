using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClickTarget();
    }

    /// <summary>
    /// 点击物体
    /// </summary>
    private void ClickTarget()
    {
        //点击鼠标左键，并且没有悬停在UI元素上方
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Clickable"));
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    player.MyTarget = hit.transform.GetChild(0).transform;

                }
            }
            else
            {
                player.MyTarget = null;
            }
        }
    }
}
