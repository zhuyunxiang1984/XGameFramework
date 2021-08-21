using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ILRuntime.Mono.Cecil.Pdb;
using ILRuntime.Runtime.CLRBinding;
using UnityEngine.Networking;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace XGameFramework
{
    /// <summary>
    /// ILRuntime运行环境
    /// </summary>
    public class XILRuntimeDomain
    {
        private AppDomain _AppDomain;

        private bool _IsRunning;
        private string _AssemblyPath;
        private string _AssemblyName;
        private bool _IsDebug;

        private UnityWebRequest _DllRequest;
        private UnityWebRequest _PdbRequest;

        private MemoryStream _DllStream;
        private MemoryStream _PdbStream;

        private Action _OnComplete;
        
        public bool IsRunning => _IsRunning;

        public void Init(bool isDebug)
        {
            _AppDomain = new AppDomain();
            _IsDebug = isDebug;
            _AppDomain.DebugService.StartDebugService(56000);
        }

        public void Start(string assemblyPath, string assemblyName, Action onComplete = null)
        {
            _AssemblyPath = assemblyPath;
            _AssemblyName = assemblyName;
            _DllRequest = UnityWebRequest.Get( $"{_AssemblyPath}{_AssemblyName}.dll");
            _DllRequest.SendWebRequest();
            if (_IsDebug)
            {
                _PdbRequest = UnityWebRequest.Get($"{_AssemblyPath}{_AssemblyName}.pdb");
                _PdbRequest.SendWebRequest();
            }
            _IsRunning = false;
            _OnComplete = onComplete;
            
        }

        public void Tick(float deltaTime)
        {
            if (_IsRunning)
                return;
            if (_DllRequest != null && _DllRequest.isDone)
            {
                _DllStream = new MemoryStream(_DllRequest.downloadHandler.data);
                _DllRequest = null;
            }
            if (_PdbRequest != null && _PdbRequest.isDone)
            {
                _PdbStream = new MemoryStream(_PdbRequest.downloadHandler.data);
                _PdbRequest = null;
            }

            if (_DllStream != null)
            {
                try
                {
                    _AppDomain.LoadAssembly(_DllStream, _PdbStream, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                    return;
                }
#if DEBUG && (UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE)
                //由于Unity的Profiler接口只允许在主线程使用，为了避免出异常，需要告诉ILRuntime主线程的线程ID才能正确将函数运行耗时报告给Profiler
                _AppDomain.UnityMainThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
#endif
                Debug.Log($"{_AssemblyName}.dll 加载完成");
                _IsRunning = true;
                _OnComplete?.Invoke();
            }
        }

        public void Invoke(string type, string method, object instance, params object[] p)
        {
            //Debug.Log($"Invoke {type}.{method}");
            _AppDomain.Invoke(type, method, instance, p);
        }

        public void CallFromHotfix(string str)
        {
            Debug.Log(str);
        }
    }

}
