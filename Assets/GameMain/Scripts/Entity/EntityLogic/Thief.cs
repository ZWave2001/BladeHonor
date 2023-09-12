using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BladeHonor
{
    public class Thief : CharacterLogic
    {
        [SerializeField] private ThiefData _ThiefData;
        [SerializeField] private Animator _Animator;
        [SerializeField] private Rigidbody2D _Rigibody;

        private AnimationClip[] _clips;
        
        private int _Walk;
        private int _Attack;
        private int _Jump;
        private int _Dash;
        private int _Hurt;
        private int _Dead;

        [SerializeField]
        private Vector2 _Direction;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnDead()
        {
            base.OnDead();
        }


        protected override void OnDamage()
        {
            base.OnDamage();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            _ThiefData = userData as ThiefData;
            _Animator = GetComponent<Animator>();
            _Rigibody = GetComponent<Rigidbody2D>();
            
            _Walk = Animator.StringToHash("Walk");
            _Attack = Animator.StringToHash("Attack");
            _Jump = Animator.StringToHash("Jump");
            _Dash = Animator.StringToHash("Dash");
            _Hurt = Animator.StringToHash("Hurt");
            _Dead = Animator.StringToHash("Dead");

            _Direction = new Vector2(1, 0);
            
            
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            _Direction.x = Input.GetAxisRaw("Horizontal");
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _Animator.SetTrigger(_Jump);
                _Rigibody.velocity = new Vector2(_Rigibody.velocity.x, 5f);
            }
            
            if (!LockMovement)
            {
                if (Math.Abs(_Direction.x) > 0.1f)
                {
                    _Animator.SetBool(_Walk, true);
                    _Rigibody.velocity = new Vector2(_Direction.x * _ThiefData.Speed, _Rigibody.velocity.y);
                    // transform.Translate(new Vector3(_Direction.x, 0, 0) * _ThiefData.Speed * Time.deltaTime);
                    transform.SetLocalScaleX(Mathf.Lerp(transform.localScale.x, -_Direction.x, 0.9f));
                }
                else
                {
                    _Rigibody.velocity = new Vector2(0, _Rigibody.velocity.y);
                    _Animator.SetBool(_Walk, false);
                }
            }

            if (StopMovement)
            {
                _Rigibody.velocity = new Vector2(0, 0);
            }
            

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!OffGround)
                {
                    _Animator.SetTrigger(_Attack);
                    StopMovement = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!StopMovement)
                {
                    _Animator.SetTrigger(_Dash);
                    transform.SetPositionX(transform.position.x + ((transform.localScale.x < 0)?1:-1) * _ThiefData.DashDistance);
                }
            }

            #region Check Grounded
            var raycastAll = Physics2D.RaycastAll(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
            OffGround = (raycastAll.Length == 0);
            LockMovement = (raycastAll.Length == 0);
            #endregion
     
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.2f);
        }

        public void shit()
        {
            
        }
    }
}

