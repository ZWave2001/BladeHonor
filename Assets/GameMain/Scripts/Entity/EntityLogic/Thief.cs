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
        [SerializeField] private Collider2D _collider;

        private AnimationClip[] _clips;
        
        private int _Walk;
        private int _Attack;
        private int _Jump;
        private int _Dash;
        private int _Hurt;
        private int _Dead;

        [SerializeField]
        private Vector2 _Direction;

        private float _dashDistance;
        
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
            _collider = GetComponent<Collider2D>();

            
            _Walk = Animator.StringToHash("Walk");
            _Attack = Animator.StringToHash("Attack");
            _Jump = Animator.StringToHash("Jump");
            _Dash = Animator.StringToHash("Dash");
            _Hurt = Animator.StringToHash("Hurt");
            _Dead = Animator.StringToHash("Dead");

            _Direction = new Vector2(1, 0);
            
            //绑定动画事件
            AddAnimationEvent(_Animator, "attack", "OnAttackComplete", 1f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            _Direction.x = Input.GetAxisRaw("Horizontal");
            
            
            if (!OffGround)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _Animator.SetTrigger(_Jump);
                    _Rigibody.velocity = new Vector2(_Rigibody.velocity.x, DefaultCharacterData.JumpVelocity);
                }
            }

            //Make Jumping Feel Better 
            if (_Rigibody.velocity.y > 0)
                _Rigibody.gravityScale = DefaultCharacterData.JumpUpGravity;
            else
                _Rigibody.gravityScale = DefaultCharacterData.JumpDownGravity;
        
            
            if (!LockMovement && !StopMovement)
            {
                if (Math.Abs(_Direction.x) > 0.1f)
                {
                    _Animator.SetBool(_Walk, true);
                    _Rigibody.velocity = new Vector2(_Direction.x * _ThiefData.Speed, _Rigibody.velocity.y);
                    // transform.Translate(new Vector3(_Direction.x, 0, 0) * _ThiefData.Speed * Time.deltaTime);
                    transform.SetLocalScaleX(-_Direction.x);
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
                    transform.SetPositionX(transform.position.x + ((transform.localScale.x < 0)?1:-1) * _dashDistance);
                }
            }

            #region Check Grounded
            var raycastAll1 = Physics2D.RaycastAll(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
            OffGround = (raycastAll1.Length == 0);
            // LockMovement = (raycastAll.Length == 0);
            
            #endregion
            
            #region Check If Can Dash

            
            var raycastAll2 = Physics2D.RaycastAll(transform.position + Vector3.up * 0.5f,
                transform.right * ((transform.localScale.x < 0) ? 1 : -1), _ThiefData.DashDistance, LayerMask.GetMask("Ground"));
            CanFullDash = (raycastAll2.Length == 0);


            if (!CanFullDash)
            {
                var distance = Mathf.Abs(transform.position.x - raycastAll2[0].point.x) - _collider.bounds.size.x / 2.0f;
                _dashDistance = distance > 0 ? distance : 0;
            }
            else
            {
                _dashDistance = _ThiefData.DashDistance;
            }

            #endregion


        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.2f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + Vector3.up * 0.5f, transform.position + Vector3.up * 0.5f +
                                                                    Vector3.right * ((transform.localScale.x < 0)?1:-1) * _ThiefData.DashDistance);
        }



        #region AnimationEvent Function

        private void OnAttackComplete()
        {
            StopMovement = false;
        }
        
        

        #endregion
    }
}

