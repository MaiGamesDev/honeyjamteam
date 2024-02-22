using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitalble
{
    public float speed; // 스피드 변수 선언
    public Rigidbody2D target; // 타겟 변수 선언
    public int health = 5; // hp

    bool isLive = true; // 우선 트루로 설정 , bool은 맞다 아니다 명령문

    Rigidbody2D rigid; // 물리변수 선언?
    SpriteRenderer spriter; // 스프라이터 방향 관련 선언

    void Awake() // start 이전에 한번만 쓰이는 함수
    {
        rigid = GetComponent<Rigidbody2D>(); // 물리 컴포넌트 저장
        spriter = GetComponent<SpriteRenderer>(); // 스프라이터 렌더러 저장
    }

    void FixedUpdate() // 물리관련 업데이트는 앞에 Fixed 붙이고 함수
    {
        if (!isLive) // 만약 살아있지 않다면 
            return; // 돌아가기

        Vector2 dirVec = target.position - rigid.position; // 타겟 위치에서 몬스터 위치 뺀 벡터값
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime; // 위 벡터값을 크기가 1인 방향벡터로 변환 * 속도 * 시간 백터값
        rigid.MovePosition(rigid.position + nextVec); // (현재위치 + nextVec) 만큼 이동
        rigid.velocity = Vector2.zero; // 물리적인 이동방식 제거 (오직 위치 연산 값으로만 이동)
    }

    void LateUpdate() // 업데이트 이후 바로 실행되는 함수
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; // 타겟의 x값이 몬스터의 x값보다 클때 몬스터 좌우반전
    }

    // 데미지 정의 선언
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
