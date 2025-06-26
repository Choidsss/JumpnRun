using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

namespace JumpNRun
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] GameObject loadingUI; // 로딩 UI 패널
        [SerializeField] Slider progressBar;   // 진행바

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingUI.SetActive(true);

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f); // 0~0.9까지 진행됨
                progressBar.value = progress;

                // 씬 로딩이 끝났을 때 자동 전환
                if (operation.progress >= 0.9f)
                {
                    // 예: 최소 몇 초 보여주기 등을 넣을 수도 있음
                    yield return new WaitForSeconds(1f);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
