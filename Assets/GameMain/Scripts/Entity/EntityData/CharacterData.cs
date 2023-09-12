// Author: ZWave
// Time: 2023/09/08 16:31
// --------------------------------------------------------------------------

using System;
using UnityEngine;

namespace BladeHonor
{
    public class CharacterData : EntityData
    {
        [SerializeField] private float _Health;
        [SerializeField] private float _Defense;
        [SerializeField] private float _Attack;
        [SerializeField] private float _Armor;
        [SerializeField] private float _Speed;
        [SerializeField] private float _DashDistance;


        public float Health
        {
            get => _Health;
            set => _Health = value;
        }

        public float Defense
        {
            get => _Defense;
            set => _Defense = value;
        }

        public float Attack
        {
            get => _Attack;
            set => _Attack = value;
        }

        public float Armor
        {
            get => _Armor;
            set => _Armor = value;
        }

        public float Speed
        {
            get => _Speed;
            set => _Speed = value;
        }

        public float DashDistance
        {
            get => _DashDistance;
            set => _DashDistance = value;
        }


        public CharacterData(int entityId, int typeId) : base(entityId, typeId)
        {
        }
    }
}