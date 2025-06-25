using UnityEngine;

namespace JumpNRun
{
    public class CarWheelsRotate : MonoBehaviour
    {

        Transform _transform;

        [SerializeField] float _speed = 1.0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            _transform.Rotate(0f, 0f, _speed * Time.fixedDeltaTime);
        }
    }
}
