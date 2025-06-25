using UnityEngine;

namespace JumpNRun
{
    public class TestTemp : MonoBehaviour
    {
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    Debug.Log("Enter : " + collision.gameObject.name);
        //}

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    Debug.Log("Stay : " + collision.gameObject.name);
        //}

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
