// Author: ZWave
// Time: 2023/09/06 11:14
// --------------------------------------------------------------------------

using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEditor;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class ProcedureMenu : GameFramework.Procedure.ProcedureBase
    {
        private bool _StartGame = false;
        private MenuForm _MenuForm = null;

        public void StartGame()
        {
            _StartGame = true;
        }
        protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);
        }
        
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            _StartGame = false;
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (_StartGame)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
                ChangeState<ProcedureMain>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if (_MenuForm != null)
            {
                _MenuForm.Close(isShutdown);
                _MenuForm = null;
            }
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
    }
}