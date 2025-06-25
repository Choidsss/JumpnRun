using UnityEngine;

namespace JumpNRun
{
    public class BackGroundScroll : MonoBehaviour
    {
        [SerializeField]float _speed = 1.0f;
       
        bool _isMoving = true;

        // Update is called once per frame
        void Update()
        {
            LayerMove();
        }


        public void LayerMove()
        {
            if (_isMoving)
            {
                Vector3 move = Vector3.left * Time.deltaTime * _speed;
                transform.position += move;

            }
        }

        
    }
}
