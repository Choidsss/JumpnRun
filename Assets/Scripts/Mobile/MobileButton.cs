using UnityEngine;
using UnityEngine.EventSystems;

namespace JumpNRun
{
    public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum Direction { Left, Right }
        public Direction moveDirection;

        [SerializeField] Jump _player; // 인스펙터에서 직접 연결

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_player == null)
            {
                Debug.LogWarning("PlayerController 참조가 연결되지 않았습니다.");
                return;
            }

            if (moveDirection == Direction.Left)
                _player.MoveLeftMobile();
            else if (moveDirection == Direction.Right)
                _player.MoveRightMobile();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_player == null)
            {
                Debug.LogWarning("PlayerController 참조가 연결되지 않았습니다.");
                return;
            }

            _player.StopMoveMobile();
        }
    }
}
