using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitalble
{
    public void Hit();
}

public class Entity : MonoBehaviour, IHitalble
{
    /// <summary>
    /// �θ� Ʈ������, ���� �θ�ü�� ���ٸ� ������ Ʈ������
    /// </summary>
    public Transform parentTr;
    public Rigidbody2D parentRg;

    public int maxHealthCount; // �ִ�ġ
    public int m_healthCount; // �����
    public int moveSpeed; // �̵��ӵ�

    public LayerMask targetLayer; // Ÿ������ �� ���̾�.

    /// <summary>
    /// ���� ���� ����
    /// </summary>
    public bool isInvisible { get { return invincibleTime > 0f; } }
    /// <summary>
    /// ���� ���� �ð�
    /// </summary>
    public float invincibleTime = 0.5f;

    public virtual void Start()
    {
        parentTr = transform.parent;
        parentRg = transform.parent.GetComponent<Rigidbody2D>();
        if (parentTr == null )
            parentTr = transform;
        if(parentRg == null)
            parentRg = parentTr.gameObject.AddComponent<Rigidbody2D>();

        parentRg.gravityScale = 0f;
    }

    public virtual void Update()
    {
        // ���� ���������� ��?
        if (isInvisible && invincibleTime > 0f)
        {
            invincibleTime -= Time.deltaTime;

            if (invincibleTime <= 0.0f)
            {
                // �����ð� ����
                //Color playerColor = playerRenderer.color;
                //playerColor.a = 1.0f; // alpha ���� 1.0���� �����Ͽ� �Ϲ����� ���·� ��ȯ
                //playerRenderer.color = playerColor;
            }
        }
    }

    void OnEnable()
    {

    }

    public void Skill1()
    {

    }

    public void Skill2()
    {

    }
    public void Skill3()
    {

    }

    public virtual void Hit()
    {
        invincibleTime = 0.5f;
    }
}
