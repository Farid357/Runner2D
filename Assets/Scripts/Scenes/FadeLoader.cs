using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLogic
{
    public sealed class FadeLoader : ILoader
    {
        private ScreenFade _screen;
        private int _sceneIndex;

        public FadeLoader(ScreenFade screen)
        {
            _screen = screen;
            _screen.OnDarkened += FadeOut;
        }

        public void FadeOut()
        {
            AsyncOperation loadOpearation = null;
            loadOpearation = SceneManager.LoadSceneAsync(_sceneIndex);
            _screen.StartFadeOut();
            _screen.OnDarkened -= FadeOut;
        }

        public void Load(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
            _screen.StartFade();
        }
    }
}
