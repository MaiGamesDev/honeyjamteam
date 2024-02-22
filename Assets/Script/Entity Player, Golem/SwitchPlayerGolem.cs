using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerGolem : MonoBehaviour
{
    public bool isGameStart;

    public Entity onFieldEntity;

    // 캐싱할 플레이어와 골렘
    public bool isPlayerTurn;
    public GameObject player;
    private Entity m_entityPlayer;
    public GameObject golem;
    private Entity m_entityGolem;

    public float switchTimeMax; // 스위치 몇 초마다 할 것인지 정하고
    private float m_switchTime; // 조작은 여기서

    private void Awake()
    {
        isGameStart = false;
        m_switchTime = 0f;
    }

    private void Start()
    {
        m_entityPlayer = player.GetComponent<Entity>();
        m_entityGolem = golem.GetComponent<Entity>();

        SetPlayerOrGolem(isPlayerTurn);
    }

    void SetPlayerOrGolem(bool _isPlayerTurn)
    {
        isPlayerTurn = _isPlayerTurn;
        player.SetActive(isPlayerTurn);
        golem.SetActive(!isPlayerTurn);

        onFieldEntity = isPlayerTurn ? m_entityPlayer : m_entityGolem;
        // 변경되면서 발생할 이펙트나 그런거 아래에 이어서 처리.

    }

    private void Update()
    {
        if (isGameStart == false) // 게임이 시작했을 경우만 실행되도록
            return;

        m_switchTime += Time.deltaTime; // 시간을 더하고
        if(m_switchTime > switchTimeMax)
        {
            m_switchTime -= switchTimeMax;
            SetPlayerOrGolem(!isPlayerTurn);
        }

        // 각자 활성화되어 있는 동안 update에서 처리
        //if (isPlayerTurn == true) // 플레이어 턴에 행동할 것들
        //{

        //}
        //else if (isPlayerTurn == false) // 골렘 턴에 행동할 것들
        //{

        //}
    }

    // 만약 객체마다 데미지값 다르게 하고싶다면 enemy쪽에서 처리하면될듯
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy")) // Enemy면 히트.
            onFieldEntity.Hit();
    }
}
