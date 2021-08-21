using UnityEditor.UI;
using UnityEngine;

namespace XGameFramework.XGameScene
{
    public abstract class XGameScene : IXGameScene
    {
        protected abstract void OnEnter();
        protected abstract void OnExit();
        protected abstract void OnTick(float deltaTime);

        private enum EnumState
        {
            None = 0,
            Enter,
            Tick,
            Exit,
        }
        private EnumState m_State;

        public void Enter()
        {
            m_State = EnumState.Enter;
        }

        public void Exit()
        {
            m_State = EnumState.Exit;
        }

        public void Tick(float deltaTime)
        {
            if (m_State == EnumState.None)
                return;
            switch (m_State)
            {
                case EnumState.Enter:
                    Debug.Log($"enter {this.ToString()}");
                    OnEnter();
                    m_State = EnumState.Tick;
                    break;
                case EnumState.Tick:
                    OnTick(deltaTime);
                    break;
                case EnumState.Exit:
                    Debug.Log($"exit {this.ToString()}");
                    OnExit();
                    m_State = EnumState.None;
                    break;
            }
        }
    }
}
