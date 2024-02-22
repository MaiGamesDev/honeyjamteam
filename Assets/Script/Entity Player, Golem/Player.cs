using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float attackRange;
    public float attackAngle;

    Vector2 moveDirection; // 키 이동
    Vector2 lookDirection; // 마우스 방향

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //base.Start();
        //parentTr = transform.parent;
        //if (parentTr == null)
        //    parentTr = transform;
    }
    
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection = moveDirection.normalized;

        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePoint - parentTr.position;
        lookDirection = lookDirection.normalized;

        if (Input.GetMouseButtonDown(0))
        {
            CheckPieArea.CheckPie(parentTr.position, lookDirection, 10f, 90f, targetLayer, (IHitalble hit) => hit.Hit());
        }
    }

    private void FixedUpdate()
    {
        Vector2 trPos = new Vector2(parentTr.position.x, parentTr.position.y);
        parentRg.MovePosition((moveDirection * moveSpeed * Time.fixedDeltaTime) + trPos);
    }

    public override void Hit()
    {
        base.Hit();
    }
}
