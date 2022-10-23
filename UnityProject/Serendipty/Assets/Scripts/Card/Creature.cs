using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : Card
{
    public int creatureType;
    public int health;
    public int power;
    public bool ableToAct;
    public int curPosition;

    public abstract void Instantiate(int pos);
    public abstract void Attack(int pos);
    public abstract void UseAbility(int index);
    public abstract void GetDamaged(int damage);
    public abstract void CounterAttack(int pos);
}
