using Unity.VisualScripting;
using UnityEngine;

namespace JumpNRun
{
    public class Jump : MonoBehaviour
    {
        // Vector2 _move;

        // Rigidbody2D _rigidBody;

        //// [SerializeField]float _jumpSpeed = 1.0f;
        // [SerializeField]float _jumpforce = 1.0f;
        // [SerializeField] float _moveSpeed = 3.0f;

        // float _jump;
        // float _horizontal;
        // bool _isGround = true;
        // int _maxJumpCount = 3;
        // int _jumpCount = 0;

        // // Start is called once before the first execution of Update after the MonoBehaviour is created
        // void Start()
        // {
        //     _rigidBody = GetComponent<Rigidbody2D>();
        // }

        // private void FixedUpdate()
        // {
        //     CarJump();
        //     HorizontalMove();
        // }

        // void CarJump()
        // {
        //     _jump = Input.GetAxis("Jump");
        //     if (_jump > 0.1 && _isGround && _jumpCount < _maxJumpCount)
        //     {
        //         Vector2 upforce = new Vector2(0f, _jumpforce);
        //         //_rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocityX, 0f);
        //         _rigidBody.AddForce(upforce , ForceMode2D.Impulse);
        //         _jumpCount++;
        //         _isGround = false;
        //     }
        // }

        // private void HorizontalMove()
        // {
        //     _horizontal = Input.GetAxis("Horizontal");
        //     Vector2 movement = _move.normalized * Time.fixedDeltaTime * _moveSpeed;
        //     _rigidBody.position += movement;
        //     _move = new Vector2(_horizontal, 0);

        // }

        // private void OnCollisionEnter2D(Collision2D collision)
        // {
        //     if(collision.gameObject.layer == 10)
        //     {
        //         _jumpCount = 0;
        //         _isGround = true;
        //     }
        // }

        //Vector2 _move;
        Rigidbody2D _rigidBody;

        [SerializeField] float _jumpForce = 7f;
        [SerializeField] float _moveSpeed = 3f;

        int _maxJumpCount = 2;
        int _jumpCount = 0;
        float _horizontal;
        float _mobileHorizontal = 0; // 모바일 입력만 따로 저장

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // ���� �Է� ó�� (��Ȯ�� �� �� ���� ����)
            if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
            {
                Jumping();
            }

            // �¿� �̵� �Է� �ޱ�
            float keyBoardInput = Input.GetAxisRaw("Horizontal");

            _horizontal = keyBoardInput + _mobileHorizontal;
            _horizontal = Mathf.Clamp(_horizontal, -1f, 1f);
        }

        void FixedUpdate()
        {
            HorizontalMove();
        }

        void Jumping()
        {
            // ���� ���� �ӵ� ���� �� ����
            _rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
        }

        void HorizontalMove()
        {
            Vector2 velocity = new Vector2(_horizontal * _moveSpeed, _rigidBody.linearVelocity.y);
            _rigidBody.linearVelocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 10) // ������ ������ ���̾�
            {
                _jumpCount = 0; // ���� ����� �� ���� ī��Ʈ ����
            }
        }

        // 🔽 모바일용 입력 메서드들
        public void MoveLeftMobile()
        {
            _mobileHorizontal = -1f;
        }

        public void MoveRightMobile()
        {
            _mobileHorizontal = 1f;
        }

        public void StopMoveMobile()
        {
            _mobileHorizontal = 0f;
        }

        public void JumpMobile()
        {
            if (_jumpCount < _maxJumpCount)
            {
                Jumping();
            }
        }
    }
}