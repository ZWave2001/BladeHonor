using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace BladeHonor
{
    [Serializable]
    public class ThiefData : CharacterData
    {
        
        public string Name
        {
            get;
            set;
        }
        
        

        public ThiefData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DRCharacter> dtCharacter = GameEntry.DataTable.GetDataTable<DRCharacter>();
            DRCharacter data = dtCharacter.GetDataRow(typeId);
            Health = data.Health;
            Attack = data.Attack;
            Defense = data.Defense;
            Speed = data.Speed;
            Armor = data.Armor;
            DashDistance = data.DashDistance;
        }
        
        
    }
    
    
    
}
