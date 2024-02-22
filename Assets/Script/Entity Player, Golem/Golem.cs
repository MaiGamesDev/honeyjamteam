using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Entity
{
    struct LearnningGolem
    {
        public int skill1;
        public int skill2;
        public int skill3;
        public int skill4;
    }

    public override void Start()
    {
        base.Start();
        //parentTr = transform.parent;
        //if (parentTr == null)
        //    parentTr = transform;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Hit()
    {
        base.Hit();
    }
}
