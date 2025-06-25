using UnityEngine;

namespace JumpNRun
{
    public class obtacleRotate : MonoBehaviour
    {
        Transform _transForm;

        [SerializeField]float _rotateSpeed = 1.0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _transForm = GetComponent<Transform>();
        }

        void Update()
        {
            _transForm.Rotate(0f, 0f, _rotateSpeed);
        }
    }
}
