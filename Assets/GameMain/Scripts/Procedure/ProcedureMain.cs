// Author: ZWave
// Time: 2023/09/06 11:15
// --------------------------------------------------------------------------

using System;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class ProcedureMain : GameFramework.Procedure.ProcedureBase
    {
        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            
            
        }
        

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            
            GameEntry.Entity.ShowCharater(new ThiefData(GameEntry.Entity.GenerateSerialId(), 1001)
            {
                Name = "Player",
                Position = new Vector3(5,17,0),
            });
            
        }
        

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }
    }
}