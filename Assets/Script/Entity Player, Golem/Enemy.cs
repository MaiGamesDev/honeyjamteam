using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitalble
{
    public float speed; // ���ǵ� ���� ����
    public Rigidbody2D target; // Ÿ�� ���� ����
    public int health = 5; // hp

    bool isLive = true; // �켱 Ʈ��� ���� , bool�� �´� �ƴϴ� ��ɹ�

    Rigidbody2D rigid; // �������� ����?
    SpriteRenderer spriter; // ���������� ���� ���� ����

    void Awake() // start ������ �ѹ��� ���̴� �Լ�
    {
        rigid = GetComponent<Rigidbody2D>(); // ���� ������Ʈ ����
        spriter = GetComponent<SpriteRenderer>(); // ���������� ������ ����
    }

    void FixedUpdate() // �������� ������Ʈ�� �տ� Fixed ���̰� �Լ�
    {
        if (!isLive) // ���� ������� �ʴٸ� 
            return; // ���ư���

        Vector2 dirVec = target.position - rigid.position; // Ÿ�� ��ġ���� ���� ��ġ �� ���Ͱ�
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime; // �� ���Ͱ��� ũ�Ⱑ 1�� ���⺤�ͷ� ��ȯ * �ӵ� * �ð� ���Ͱ�
        rigid.MovePosition(rigid.position + nextVec); // (������ġ + nextVec) ��ŭ �̵�
        rigid.velocity = Vector2.zero; // �������� �̵���� ���� (���� ��ġ ���� �����θ� �̵�)
    }

    void LateUpdate() // ������Ʈ ���� �ٷ� ����Ǵ� �Լ�
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; // Ÿ���� x���� ������ x������ Ŭ�� ���� �¿����
    }

    // ������ ���� ����
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        TakeDamage(1);
        Debug.Log(gameObject.name);
    }
}
