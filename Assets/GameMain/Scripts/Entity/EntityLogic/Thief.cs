using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BladeHonor
{
    public class Thief : CharacterLogic
    {
        [SerializeField] private ThiefData _ThiefData;
        
        protected override void OnDead()
        {
            base.OnDead();
        }


        protected override void OnDamage()
        {
            base.OnDamage();
        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            _ThiefData = userData as ThiefData;
        }
    }
}

