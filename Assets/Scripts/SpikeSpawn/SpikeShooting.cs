using UnityEngine;

namespace JumpNRun
{
    public class SpikeShooting : MonoBehaviour
    {
        [SerializeField] float _shootingForce = 10.0f;
        Rigidbody2D _rigid;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();

            //Debug.Log("»Æ¿Œ");
            Vector2 force = new Vector2(_shootingForce, 0f);
            _rigid.AddForce(force, ForceMode2D.Impulse);
        }

    }
}
