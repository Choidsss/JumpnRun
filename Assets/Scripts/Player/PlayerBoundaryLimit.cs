using UnityEngine;

namespace JumpNRun
{
    public class PlayerBoundaryLimit : MonoBehaviour
    {
        Camera _mainCamera;
        float _halfWidth;
        float _halfHeight;

        void Start()
        {
            _mainCamera = Camera.main;

            // 플레이어의 스프라이트 크기 고려 (Collider가 있으면 Collider.bounds.extents 사용도 가능)
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                _halfWidth = sr.bounds.extents.x;
                _halfHeight = sr.bounds.extents.y;
            }
            else
            {
                _halfWidth = 0.5f;
                _halfHeight = 0.5f;
            }
        }

        void LateUpdate()
        {
            Vector3 pos = transform.position;

            // 카메라 화면의 World 좌표 기준 경계 계산
            Vector3 min = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.nearClipPlane));
            Vector3 max = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, _mainCamera.nearClipPlane));

            // x, y 위치를 화면 안쪽으로 클램프
            pos.x = Mathf.Clamp(pos.x, min.x + _halfWidth, max.x - _halfWidth);
            pos.y = Mathf.Clamp(pos.y, min.y + _halfHeight, max.y - _halfHeight);

            transform.position = pos;
        }
    }
}
