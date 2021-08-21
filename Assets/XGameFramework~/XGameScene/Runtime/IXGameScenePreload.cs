using UnityEngine;

namespace XGameFramework.XGameScene.Runtime
{
    public interface IXGameScenePreload
    {
        void Start(IXGameScene src, IXGameScene dst);
        void Tick(float deltaTime);
        bool IsCompleted();
    }
}
