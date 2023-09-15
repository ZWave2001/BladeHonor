// Author: ZWave
// Time: 2023/09/15 14:23
// --------------------------------------------------------------------------

using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace BladeHonor
{
    public class ProcedureCheckVersion : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }
    }
}