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
    /// 부모 트랜스폼, 만약 부모객체가 없다면 본인의 트랜스폼
    /// </summary>
    public Transform parentTr;
    public Rigidbody2D parentRg;

    public int maxHealthCount; // 최대치
    public int m_healthCount; // 생명력
    public int moveSpeed; // 이동속도

    public LayerMask targetLayer; // 타겟으로 할 레이어.

    /// <summary>
    /// 무적 상태 여부
    /// </summary>
    public bool isInvisible { get { return invincibleTime > 0f; } }
    /// <summary>
    /// 무적 지속 시간
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
        // 만약 무적상태일 때?
        if (isInvisible && invincibleTime > 0f)
        {
            invincibleTime -= Time.deltaTime;

            if (invincibleTime <= 0.0f)
            {
                // 무적시간 종료
                //Color playerColor = playerRenderer.color;
                //playerColor.a = 1.0f; // alpha 값을 1.0으로 설정하여 일반적인 상태로 전환
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
