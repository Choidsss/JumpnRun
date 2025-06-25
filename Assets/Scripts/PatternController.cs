using UnityEngine;
using System.Collections;

namespace JumpNRun
{
    public class PatternController : MonoBehaviour
    {
        [SerializeField] GameObject _PatternSpawner;
        [SerializeField] GameObject _Pattern6Obj;
        [SerializeField] float _spawmerInterval = 15.0f;
        [SerializeField] float _pattern6Interval = 10.0f;
       // [SerializeField]float _patternDelay = 3.0f;

        bool _isPattern6Obj = true;
        bool _isPatternSpawner = false;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(PatternControl());
        }


        IEnumerator PatternControl()
        {
            while (true)
            {
                if (_isPattern6Obj)
                {
                    _Pattern6Obj.SetActive(true);
                    _PatternSpawner.SetActive(false);
                    
                    _isPattern6Obj = false;
                    _isPatternSpawner = true;

                    yield return new WaitForSeconds(_pattern6Interval);
                }
                else
                {
                    _Pattern6Obj.SetActive(false);
                    _PatternSpawner.SetActive(true);
                    
                    _isPattern6Obj = true;
                    _isPatternSpawner = false;
                    yield return new WaitForSeconds(_spawmerInterval);
                }
                //yield return new WaitForSeconds(_patternDelay);
            }
        }
    }
}
