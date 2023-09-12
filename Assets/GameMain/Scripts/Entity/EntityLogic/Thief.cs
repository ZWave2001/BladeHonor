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

        [SerializeField]
        private int _Walk;
        [SerializeField]
        private int _Attack;
        [SerializeField]
        private int _Jump;
        [SerializeField]
        private int _Dash;
        [SerializeField]
        private int _Hurt;
        [SerializeField]
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
                _Direction.y = 1;
            }

            if (Math.Abs(_Direction.x) > 0.1f)
            {
                _Animator.SetBool(_Walk, true);
                transform.Translate(new Vector3(_Direction.x, 0, 0) * _ThiefData.Speed * Time.deltaTime);
                transform.SetLocalScaleX(Mathf.Lerp(transform.localScale.x, -_Direction.x, 0.8f));
            }
            else
            {
                _Animator.SetBool(_Walk, false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _Animator.SetTrigger(_Attack);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _Animator.SetTrigger(_Dash);
                transform.SetPositionX(transform.position.x + ((transform.localScale.x < 0)?1:-1) * _ThiefData.DashDistance);
            }
            
            
        }

        
    }
}

