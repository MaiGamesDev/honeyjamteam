using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerGolem : MonoBehaviour
{
    public bool isGameStart;

    public Entity onFieldEntity;

    // ĳ���� �÷��̾�� ��
    public bool isPlayerTurn;
    public GameObject player;
    private Entity m_entityPlayer;
    public GameObject golem;
    private Entity m_entityGolem;

    public float switchTimeMax; // ����ġ �� �ʸ��� �� ������ ���ϰ�
    private float m_switchTime; // ������ ���⼭

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
        // ����Ǹ鼭 �߻��� ����Ʈ�� �׷��� �Ʒ��� �̾ ó��.

    }

    private void Update()
    {
        if (isGameStart == false) // ������ �������� ��츸 ����ǵ���
            return;

        m_switchTime += Time.deltaTime; // �ð��� ���ϰ�
        if(m_switchTime > switchTimeMax)
        {
            m_switchTime -= switchTimeMax;
            SetPlayerOrGolem(!isPlayerTurn);
        }

        // ���� Ȱ��ȭ�Ǿ� �ִ� ���� update���� ó��
        //if (isPlayerTurn == true) // �÷��̾� �Ͽ� �ൿ�� �͵�
        //{

        //}
        //else if (isPlayerTurn == false) // �� �Ͽ� �ൿ�� �͵�
        //{

        //}
    }

    // ���� ��ü���� �������� �ٸ��� �ϰ�ʹٸ� enemy�ʿ��� ó���ϸ�ɵ�
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy")) // Enemy�� ��Ʈ.
            onFieldEntity.Hit();
    }
}
