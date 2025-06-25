using UnityEngine;

namespace JumpNRun
{
    public class PatternDespawn : MonoBehaviour
    {

        [SerializeField] Pattern6Fire _fire;

        private void OnCollisionExit2D(Collision2D collision)
        {
            DangerSpike ds = collision.transform.GetComponent<DangerSpike>();
            if (ds != null)
            {
                Destroy(collision.gameObject);
                _fire.SpawnCount--;

            }
        }
    }
}
