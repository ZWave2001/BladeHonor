// Author: ZWave
// Time: 2023/09/06 11:14
// --------------------------------------------------------------------------

using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameMain.Scripts.Event;
using UnityEditor;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class ProcedureMenu : GameFramework.Procedure.ProcedureBase
    {
        private MenuForm _MenuForm = null;
        private IFsm<IProcedureManager> _procedureOwner;
        
        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
            _procedureOwner = procedureOwner;
        }
        
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.Event.Subscribe(SelectLevelEventArgs.EventId, StartGame);

            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            GameEntry.Event.Unsubscribe(SelectLevelEventArgs.EventId, StartGame);
            
            // if (_MenuForm != null)
            // {
            //     _MenuForm.Close(isShutdown);
            //     _MenuForm = null;
            // }
        }
        
        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            _MenuForm = (MenuForm)ne.UIForm.Logic;
        }


        private void StartGame(object sender, GameEventArgs e)
        {
            SelectLevelEventArgs ne = (SelectLevelEventArgs)e;
            _procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
            _procedureOwner.SetData<VarInt32>("NextLevelId", ne.LevelId);
            
            ChangeState<ProcedureChangeScene>(_procedureOwner);
        }
    }
}