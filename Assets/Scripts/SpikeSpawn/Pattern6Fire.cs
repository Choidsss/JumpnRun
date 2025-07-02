using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Net;

namespace JumpNRun
{
    public class Pattern6Fire : MonoBehaviour
    {
        [SerializeField] GameObject[] prefabs;

        Vector2 _spawnAreaMin = new Vector2(-2f, -1f);
        Vector2 _spawnAreaMax = new Vector2(2f, 1f);

        int _count = 0;
        int _maxCount = 3;

        float _time = 0f;
        float _interval = 2.0f;

        public int SpawnCount { get { return _count; } set { _count = value; } }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _spawnAreaMin = (Vector2)transform.position + _spawnAreaMin;
            _spawnAreaMax = (Vector2)transform.position + _spawnAreaMax;
        }


        private void FixedUpdate()
        {
            _time += Time.fixedDeltaTime;

            if(_time >= _interval)
            {
                if (_count < _maxCount)
                {
                    Vector2 spawnPosition = new Vector2(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x), Random.Range(_spawnAreaMin.y, _spawnAreaMax.y));
                    Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition, Quaternion.identity);
                    _count++;
                }
                _time = 0f;
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
