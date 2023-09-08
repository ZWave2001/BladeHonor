﻿// Author: ZWave
// Time: 2023/09/08 17:00
// --------------------------------------------------------------------------

using System;
using UnityEngine;

namespace BladeHonor
{
    public class CharacterLogic : Entity
    {
        [SerializeField]
        private CharacterData _CharacterData;
        
        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDead()
        {
            
        }

        protected virtual void OnDamage()
        {
            
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            _CharacterData = userData as CharacterData;
        }
    }
}