using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ��ġ�ϰ� �갡 �÷��̾� ����ٴ� ����
/// </summary>
public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    public float generateTime;
    private float m_GenerateTime;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        m_GenerateTime += Time.deltaTime;

        if (m_GenerateTime > generateTime)
        {
            m_GenerateTime = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length)].position;
    }
}
