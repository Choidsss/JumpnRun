using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

namespace JumpNRun
{
    public class TestJump : MonoBehaviour
    {
        //Rigidbody2D _rigid;
        //TestMove _testMove;

        //float _horizontal;
        //float _vertical;
        //float _jump;
        //bool _isGround = true;

        //[SerializeField]float _jumpSpeed = 1.0f;

        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //void Start()
        //{
        //    _rigid = GetComponent<Rigidbody2D>();
        //    _testMove = GetComponent<TestMove>();
        //}

        //private void FixedUpdate()
        //{

        //}

        //public void Jumping()
        //{
        //    if (_isGround == true && Input.GetButtonDown("space"))
        //    {
        //       // _jump
        //    }
        //}
        
        
        
        [SerializeField]
        float _speed = 10f;
        [SerializeField]
        float _jumpForce = 7.0f;

        float _jumpPressed;
        float _horizontal;
        float _maxSpeed = 5;
        Rigidbody2D _rb;
        Animator _anim;
        bool _isJump = false;
        float _gravityAcceleration = 9.81f;

        // Start is called before the first frame update
        void Start()
        {
            //RigidBody와Animator를 가져옴
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            Move();

            StartCoroutine(Jumping());

            //if (_jumpPressed > 0.1f && !_isJump)
            //{
            //    _isJump = true;
            //    Debug.Log("Jumped!!!");
            //    _rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            //}

        }

        // Update is called once per frame
        void Update()
        {
            _jumpPressed = Input.GetAxis("Jump");
            _horizontal = Input.GetAxis("Horizontal");
        }

        public void Move()
        {
            Vector2 move = new Vector2(_horizontal, 0);

            if (!Mathf.Approximately(move.x, 0.0f))
            {
                _rb.AddForce(move * _speed, ForceMode2D.Impulse);
                _rb.linearVelocity = new Vector2(Mathf.Clamp(_rb.linearVelocity.x, -_maxSpeed, _maxSpeed), _rb.linearVelocity.y);
                //Vector2 position = _rb.position;
                //position += move * _speed * Time.deltaTime;
                //_rb.MovePosition(position);
            }
            else
            {
                _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
                //_rb.velocity = new Vector2(_rb.velocity.normalized.x, _rb.velocity.y);
            }

            // TODO : _horizontal의 값이 음으로 가면 scale x를 -
            if (_horizontal < -0.1f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            _anim.SetFloat("Speed", move.magnitude);
        }

        public IEnumerator Jumping()
        {
            Vector3 velocity = _rb.linearVelocity;

            if (_isJump)
            {
                velocity.y -= _gravityAcceleration * Time.fixedDeltaTime;
                _rb.linearVelocity = velocity;
            }

            if (!Mathf.Approximately(_jumpPressed, 0.0f))
            {
                if (!_isJump)
                {
                    _isJump = true;
                    velocity.y = _jumpForce;
                    _rb.linearVelocity = velocity;
                    //_rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                }
            }
            yield return null;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                _isJump = false;
            }
        }
    }
}
