using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireDemon : Creature
{
    public void UpdateInfoText()
    {
        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = power.ToString();
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = health.ToString();
    }

    IEnumerator DeathCoroutine()
    {
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetTrigger("Death");

        yield return new WaitForSecondsRealtime(1.067f);

        Destroy(gameObject);
    }

    IEnumerator GetDamagedCoroutine()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 148f / 255f, 148f / 255f, 1f);
        transform.GetChild(2).GetChild(0).GetComponent<Text>().color = new Color(1f, 80f / 255f, 80f / 255f, 1f);

        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetTrigger("GetDamaged");

        yield return new WaitForSecondsRealtime(0.683f);

        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        transform.GetChild(2).GetChild(0).GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
    }

    IEnumerator AttackCoroutine(int pos)
    {
        if (curPosition / 6 == 0)
        {
            transform.position = FieldManager.Instance.fieldObject[pos].transform.position + new Vector3(-7f, 0f, 0f);
        }
        else
        {
            transform.position = FieldManager.Instance.fieldObject[pos].transform.position + new Vector3(7f, 0f, 0f);
        }

        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetTrigger("Attack");

        yield return new WaitForSecondsRealtime(0.280f);

        FieldManager.Instance.fieldObject[pos].transform.GetChild(0).GetComponent<Creature>().GetDamaged(power);

        yield return new WaitForSecondsRealtime(0.487f);

        transform.position = FieldManager.Instance.fieldObject[curPosition].transform.position;
        isAttackFinished = true;
    }

    public override void Instantiate(int pos)
    {
        cardIndex = StaticVariable.FireDemon;
        cardClass = StaticVariable.Normal;
        cardProperty = StaticVariable.Fire;
        cardType = StaticVariable.Creature;
        cost = 5;
        additionalCost = 0;

        power = 100;
        health = 100;
        ableToAct = true;
        curPosition = pos;
        isAttackFinished = false;
        UpdateInfoText();
    }

    public override void Attack(int pos)
    {
        StartCoroutine(AttackCoroutine(pos));
    }

    public override void UseAbility(int index)
    {

    }

    public override void GetDamaged(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            power = health;
            UpdateInfoText();
            StartCoroutine(GetDamagedCoroutine());
        }
        else
        {
            health = 0;
            UpdateInfoText();
            Death();
        }
    }

    public override void Death()
    {
        if (curPosition / 6 == 0)
        {
            GraveManager.Instance.Add(0, cardIndex);
        }
        else
        {
            GraveManager.Instance.Add(1, cardIndex);
        }
        StartCoroutine(DeathCoroutine());
    }

    public override void Active()
    {
        ableToAct = true;
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetBool("ableToAct", true);
    }

    public override void Deactive()
    {
        ableToAct = false;
        Animator animator = transform.GetChild(0).GetComponent<Animator>();
        animator.SetBool("ableToAct", false);
    }
}
