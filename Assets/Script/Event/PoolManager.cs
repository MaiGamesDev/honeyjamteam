using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리펩들 보관할 장소
    public GameObject[] prefabs;

    //풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        // 선택한 풀의 놀고 있는 (비활성화 된) 게임오브젝트 접근


        foreach (GameObject item in pools[i])
        {
            if (!item.activeSelf)
            {// 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못찾았으면?
        // 새롭게 생성하고 select 변수에 할당

        if (select == null)
        {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
