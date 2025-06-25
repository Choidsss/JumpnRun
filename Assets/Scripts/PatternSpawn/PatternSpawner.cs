using UnityEngine;

namespace JumpNRun
{
    
    public class PatternSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] PatternType;

        Vector2 _spawnAreaMin = new Vector2(-1f, -0.1f);
        Vector2 _spawnAreaMax = new Vector2(1f, 0.1f);
        
        int _count = 0;
        int _maxCount = 1;

        public int PatternSpawnCount { get { return _count; } set { _count = value; } } 
        public int SpawnCount { get { return _count; } set { _count = value; } }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _spawnAreaMin = (Vector2)transform.position + _spawnAreaMin;
            _spawnAreaMax = (Vector2)transform.position + _spawnAreaMax;
        }


        private void FixedUpdate()
        {
            if (_count < _maxCount)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x), Random.Range(_spawnAreaMin.y, _spawnAreaMax.y));
                Instantiate(PatternType[Random.Range(0, PatternType.Length)], spawnPosition, Quaternion.identity);
                _count++;
            }
            else
            {
                return;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Vector2 center = transform.position;
            Vector3 size = new Vector3(_spawnAreaMax.x - _spawnAreaMin.x,
                                       _spawnAreaMax.y - _spawnAreaMin.y, 0);
            Gizmos.DrawWireCube(center, size);
        }
    }
}
