using UnityEngine;

namespace JumpNRun
{
    public class TestMove : MonoBehaviour
    {
        float _vertical;
        float _horizontal;
        
        [SerializeField]float _moveSpeed = 1.0f;

        Vector2 _move;
        Vector2 _lookDirection;

        Rigidbody2D _rigid;
        
        public Vector2 LookDirection { get {return _lookDirection; } }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Charactermove();
            GetDirection();
        }

        public void Charactermove()
        {
            //움직임
            Vector2 movement = _move.normalized * Time.fixedDeltaTime * _moveSpeed;

            //느리게 내려오는 문제
            _rigid.MovePosition(_rigid.position + movement);
        }

        public void GetDirection()
        {
            //x축 y축의 키입력을 받음
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            
            //어디를 바라보는지 좌표를 _move로 확인
            _move = new Vector2(_horizontal, _vertical);

            if (_move.magnitude > 0.1f)
            {
                _lookDirection = _move.normalized;
            }
            else
            {
                //변화 없음
                _move = Vector2.zero;
            }
        }
    }
}
