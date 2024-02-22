using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public static class CheckPieArea
{
    // ��ä�� �� �Ǻ�
    // ���� ��ġ
    // Ÿ���� ��ǥ overlapCollider
    // �Ÿ� overlapColliedr�� �Ÿ��� �����Ƿ� �ʿ����
    // ���հ�
    // CheckPie(tr.position, b, dis, angle);
    /// <summary>
    /// ��ä�� ���� üũ
    /// </summary>
    /// <param name="startPos">���� ��ġ</param>
    /// <param name="direction">����</param>
    /// <param name="distance">�Ÿ�</param>
    /// <param name="angle">����</param>
    /// <param name="action">������ �Լ�</param>
    public static void CheckPie(Vector2 startPos, Vector2 direction, float distance, float angle, int layer, Action<IHitalble> action)
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(startPos, distance, layer);
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector2 temp = new Vector2(enemys[i].gameObject.transform.position.x, enemys[i].gameObject.transform.position.y);
            Vector2 dir = temp - startPos; // ���� ����Ű�� ���� ����
            dir = dir.normalized; // ����ȭ ���Ѽ� ũ�� 1�� ���� ����

            float dot = Vector2.Dot(dir, direction); // ����� �� ������ ����. ������ ���ϱ� ����
            float theta = Mathf.Acos(dot); // cos�� ���� ���� ������ ����
            float degree = Mathf.Rad2Deg * theta;

            if (degree <= angle / 2f)
            {
                // ���� �ȿ� ����
                IHitalble hitable = enemys[i].gameObject.GetComponent<IHitalble>();
                if(hitable != null)
                    action?.Invoke(hitable);
            }
            else
            {
                // ���� ��
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
