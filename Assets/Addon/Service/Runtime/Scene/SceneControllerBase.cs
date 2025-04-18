using Services.Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Services.SceneManagement
{
    public class SceneControllerBase : Service, ISceneController
    {
        [AutoService]
        protected IEventSystem eventSystem;

        protected SceneControllerCore core;

        /// <summary>
        /// 是否异步加载场景
        /// </summary>
        public bool async;
        /// <summary>
        /// 异步加载场景时是否需要确认
        /// </summary>
        public bool needConfirm;

        public UnityEvent<AsyncOperation> AsyncLoadScene => core.AsyncLoadScene;

        public void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
            => core.LoadScene(SceneControllerUtility.ToSceneIndex(name), mode, async, needConfirm);
        public void LoadScene(int index, LoadSceneMode mode = LoadSceneMode.Single)
            => core.LoadScene(index, mode, async, needConfirm);
        public void LoadNextScene(LoadSceneMode mode = LoadSceneMode.Single)
            => LoadScene(SceneControllerUtility.SceneIndex + 1, mode);

        public void UnloadScene(string name, UnloadSceneOptions options = UnloadSceneOptions.None)
           => core.UnLoadScene(SceneControllerUtility.ToSceneIndex(name), options);
        public void UnloadScene(int index, UnloadSceneOptions options = UnloadSceneOptions.None)
            => core.UnLoadScene(index, options);

        public void Quit()
            => core.Quit();

        private void BeforeLoadScene(int index)
        {
            eventSystem.Invoke(EEvent.BeforeLoadScene, index);
        }
        private void AfterLoadScene(int index)
        {
            eventSystem.Invoke(EEvent.AfterLoadScene, index);
        }
        private void BeforeUnLoadScene(int index)
        {
            eventSystem.Invoke(EEvent.BeforeUnLoadScene, index);
        }
        private void AfterUnLoadScene(int index)
        {
            eventSystem.Invoke(EEvent.AfterUnLoadScene, index);
        }

        protected override void Awake()
        {
            base.Awake();
            core = new SceneControllerCore(this, BeforeLoadScene, AfterLoadScene, BeforeUnLoadScene, AfterUnLoadScene);
        }
    }
}