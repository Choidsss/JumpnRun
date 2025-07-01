using UnityEngine;

namespace JumpNRun
{
    public class AreaDespawn : MonoBehaviour
    {
        [SerializeField] Pattern6Fire _fire;
        [SerializeField] PatternSpawner _sapwner;
        [SerializeField] float _addDistance = 3.7f;

        BoxCollider2D _collider;

        float _offsetX;

       
        private void Start()
        {
            //_fire = GetComponent<Pattern6Fire>();
            _collider = GetComponent<BoxCollider2D>();

            _offsetX = _collider.bounds.extents.x;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            DangerSpike ds = collision.transform.GetComponent<DangerSpike>();
            if(ds != null)
            {
                Destroy(collision.gameObject);
                _fire.SpawnCount--;

            }
            else if (collision.CompareTag("Pattern"))
            {
                Destroy(collision.gameObject);
                _sapwner.PatternSpawnCount--;
                //Debug.Log("패턴 사라짐");
            }
                //Debug.Log("확인");
                Vector3 DespawnPosX = new Vector3(_offsetX * _addDistance, 0, 0);
            collision.transform.position += DespawnPosX;
        }
    }
}