using UnityEngine;

namespace SceneLogic
{
    public sealed class SceneLoaderByIndex : MonoBehaviour, ILoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private ScreenFade _screen;
        private ILoader _loaders;

        private void Start()
        {
            _loaders = new FadeLoader(_screen);
        }

        public void Load(int sceneIndex)
        {
            _loaders.Load(sceneIndex);
        }
    }
    public enum SceneLoadMode
    {
        Simple,
        Fade,
        WithLoadScreen
    }
    public interface ILoader
    {
        public void Load(int sceneIndex);
    }
}
