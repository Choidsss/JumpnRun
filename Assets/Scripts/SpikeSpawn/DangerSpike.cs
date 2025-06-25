using UnityEngine;

namespace JumpNRun
{
    public class DangerSpike : MonoBehaviour
    {
        SpriteRenderer _spriteRenderer;

        bool _isPlayerDead = false;

        public bool IsPlayerDead{ get { return _isPlayerDead; }  }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = Color.red;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 10)
            {
                return;
            }
            Destroy(collision.gameObject);
            _isPlayerDead = true;

        }

    }
}
