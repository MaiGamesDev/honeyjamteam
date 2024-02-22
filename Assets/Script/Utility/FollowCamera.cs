using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public static class CheckPieArea
{
    // 부채꼴 적 판별
    // 시작 위치
    // 타겟의 좌표 overlapCollider
    // 거리 overlapColliedr로 거리를 쟀으므로 필요없음
    // 사잇각
    // CheckPie(tr.position, b, dis, angle);
    /// <summary>
    /// 부채꼴 범위 체크
    /// </summary>
    /// <param name="startPos">시작 위치</param>
    /// <param name="direction">방향</param>
    /// <param name="distance">거리</param>
    /// <param name="angle">각도</param>
    /// <param name="action">실행할 함수</param>
    public static void CheckPie(Vector2 startPos, Vector2 direction, float distance, float angle, int layer, Action<IHitalble> action)
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(startPos, distance, layer);
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector2 temp = new Vector2(enemys[i].gameObject.transform.position.x, enemys[i].gameObject.transform.position.y);
            Vector2 dir = temp - startPos; // 몹을 가리키는 방향 벡터
            dir = dir.normalized; // 정규화 시켜서 크기 1인 방향 벡터

            float dot = Vector2.Dot(dir, direction); // 정면과 몹 방향을 내적. 각도를 구하기 위함
            float theta = Mathf.Acos(dot); // cos의 역을 취해 각도를 구함
            float degree = Mathf.Rad2Deg * theta;

            if (degree <= angle / 2f)
            {
                // 범위 안에 있음
                IHitalble hitable = enemys[i].gameObject.GetComponent<IHitalble>();
                if(hitable != null)
                    action?.Invoke(hitable);
            }
            else
            {
                // 범위 밖
            }
        }
    }
}

public class FollowCamera : MonoBehaviour
{
    public float moveSpeed;

    public Transform m_Target;
    public Vector3 offset;
    private Vector3 lerpTarget;
    public float mouseLerpValue;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    [ContextMenu("SetOffset")]
    public void SetOffset()
    {
        offset = transform.position;
    }

    private void Update()
    {
        if (m_Target == null)
            return;
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lerpTarget = m_Target.position + (mousePoint * mouseLerpValue);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_Target == null)
            return;
        transform.position = Vector3.Lerp(transform.position, lerpTarget + offset, Time.deltaTime * moveSpeed);
        //transform.position = Vector3.Lerp(transform.position, m_Target.position + offset, Time.deltaTime * moveSpeed);
    }
}
