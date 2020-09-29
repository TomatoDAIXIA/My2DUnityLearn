using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Spell
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float casttime;
    [SerializeField]
    private GameObject spellPrefab;
    [SerializeField]
    private Color barColor;

    public string MyName { get => name; }
    public int MyDamage { get => damage;  }
    public Sprite MyIcon { get => icon; }
    public float MySpeed { get => speed;  }
    public float MyCasttime { get => casttime; }
    public GameObject MySpellPrefab { get => spellPrefab; }
    public Color MyBarColor { get => barColor;}
}
