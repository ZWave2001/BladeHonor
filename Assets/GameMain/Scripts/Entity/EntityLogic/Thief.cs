using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace BladeHonor
{
    public class Thief : CharacterLogic
    {
        [SerializeField] private ThiefData _thiefData;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigibody;
        [SerializeField] private Collider2D _collider;

        private AnimationClip[] _clips;

        private int _walk;
        private int _attack;
        private int _jump;
        private int _dash;
        private int _hurt;
        private int _dead;

        [SerializeField] private Vector2 _direction;

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
            _thiefData = userData as ThiefData;
            _animator = GetComponent<Animator>();
            _rigibody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();


            _walk = Animator.StringToHash("Walk");
            _attack = Animator.StringToHash("Attack");
            _jump = Animator.StringToHash("Jump");
            _dash = Animator.StringToHash("Dash");
            _hurt = Animator.StringToHash("Hurt");
            _dead = Animator.StringToHash("Dead");

            _direction = new Vector2(1, 0);

            //绑定动画事件
            AddAnimationEvent(_animator, "attack", "OnAttackComplete", 1f);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            _direction.x = Input.GetAxisRaw("Horizontal");


            if (!OffGround)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _animator.SetTrigger(_jump);
                    _rigibody.velocity = new Vector2(_rigibody.velocity.x, DefaultCharacterData.JumpVelocity);
                }
            }

            //Make Jumping Feel Better 
            if (_rigibody.velocity.y > 0)
                _rigibody.gravityScale = DefaultCharacterData.JumpUpGravity;
            else
                _rigibody.gravityScale = DefaultCharacterData.JumpDownGravity;


            if (!LockMovement && !StopMovement)
            {
                if (Math.Abs(_direction.x) > 0.1f)
                {
                    _animator.SetBool(_walk, true);
                    _rigibody.velocity = new Vector2(_direction.x * _thiefData.Speed, _rigibody.velocity.y);
                    // transform.Translate(new Vector3(_direction.x, 0, 0) * _thiefData.Speed * Time.deltaTime);
                    transform.SetLocalScaleX(-_direction.x);
                }
                else
                {
                    _rigibody.velocity = new Vector2(0, _rigibody.velocity.y);
                    _animator.SetBool(_walk, false);
                }
            }

            if (StopMovement)
            {
                _rigibody.velocity = new Vector2(0, 0);
            }


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!OffGround)
                {
                    _animator.SetTrigger(_attack);
                    StopMovement = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!StopMovement)
                {
                    _animator.SetTrigger(_dash);
                    transform.SetPositionX(transform.position.x +
                                           ((transform.localScale.x < 0) ? 1 : -1) * _dashDistance);
                }
            }

            #region Check Grounded

            var raycastAll1 = Physics2D.RaycastAll(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
            OffGround = (raycastAll1.Length == 0);
            // LockMovement = (raycastAll.Length == 0);

            #endregion

            #region Check If Can FullDash

            var raycastAll2 = Physics2D.RaycastAll(transform.position + Vector3.up * 0.5f,
                transform.right * ((transform.localScale.x < 0) ? 1 : -1), _thiefData.DashDistance,
                LayerMask.GetMask("Ground"));
            CanFullDash = (raycastAll2.Length == 0);


            if (!CanFullDash)
            {
                var distance = Mathf.Abs(transform.position.x - raycastAll2[0].point.x) -
                               _collider.bounds.size.x / 2.0f;
                _dashDistance = distance > 0 ? distance : 0;
            }
            else
            {
                _dashDistance = _thiefData.DashDistance;
            }

            #endregion
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.2f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + Vector3.up * 0.5f, transform.position + Vector3.up * 0.5f +
                                                                    Vector3.right *
                                                                    ((transform.localScale.x < 0) ? 1 : -1) *
                                                                    _thiefData.DashDistance);
        }


        #region AnimationEvent Function

        private void OnAttackComplete()
        {
            StopMovement = false;
        }

        #endregion
    }
}