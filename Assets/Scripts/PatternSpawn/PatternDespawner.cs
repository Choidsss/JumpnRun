using UnityEngine;

namespace JumpNRun
{
    public class PatternDespawner : MonoBehaviour
    {

        private void OnTriggerExit2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            Debug.Log("패턴 디스폰");
        }
    }
}
