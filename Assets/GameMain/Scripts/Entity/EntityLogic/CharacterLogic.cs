// Author: ZWave
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

        [SerializeField]
        public bool IsHurt
        {
            get;
            set;
        }

        [SerializeField]
        public bool IsWalk
        {
            get;
            set;
        }

        [SerializeField]
        public bool OffGround
        {
            get;
            set;
        }

        [SerializeField]
        public bool LockMovement
        {
            get;
            set;
        }

        [SerializeField]
        public bool StopMovement
        {
            get;
            set;
        }

        [SerializeField]
        public bool CanFullDash
        {
            get;
            set;
        }
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
        
        /// <summary>
        /// 动态添加动画事件
        /// </summary>
        /// <param name="animator">动画控制器</param>
        /// <param name="animName">动画片段名字</param>
        /// <param name="funcName">添加的方法名</param>
        /// <param name="animTime">插入事件的时间（0-1）</param>
        protected virtual void AddAnimationEvent(Animator animator, string animName, string funcName, float animTime)
        {
            AnimationEvent animEvent = new AnimationEvent()
            {
                functionName = funcName,
                time = animTime,
            };
            foreach (var clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name.Equals(animName))
                {
                    animEvent.time = clip.length * animEvent.time;
                    clip.AddEvent(animEvent);
                }
            }
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