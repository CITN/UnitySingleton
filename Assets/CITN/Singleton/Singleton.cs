using CITN.Singleton.Settings;
using CITN.Singleton.Util;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
        {
            protected static bool _isAlive = true;

            private static T _instance = null;
            private static SingletonSettings _settings = null;
            private static object _lockObject = new object();

            private bool _isInitialized;

            protected abstract void OnInitCallback();
            protected abstract void OnApplicationQuitCallback();
            protected abstract void OnDestroyCallback();

            private void Awake()
            {
                if (!_isAlive || ThisIsEmpty)
                {
                    return;
                }

                if (InstanceIsEmpty)
                {
                    _instance = this as T;
                }

                SetSettings();
                if (!InstanceIsThis)
                {
                    SingletonDestroyUtil<T>.Destroy(this, _settings);
                    return;
                }

                _instance.Init();
            }

            private void OnDestroy() 
            {
                StopAllCoroutines();
                RemoveListener();
                if (InstanceIsThis)
                {
                    NotAlive();
                    ClearSettings();
                    ClearInstance();
                }
                OnDestroyCallback();
            }

            private void OnApplicationQuit() 
            {
                NotAlive();
                ClearSettings();
                ClearInstance();
                OnApplicationQuitCallback();
            }

            public void Init()
            {
                if (_isInitialized)
                {
                    return;
                }

                if (_settings.DontDestroyOnLoadScene)
                {
                    DontDestroyOnLoad(gameObject);
                }

                if (_settings.DeactivateOnLoad)
                {
                    gameObject.SetActive(false);
                }
                _isInitialized = true;
                AddListener();
                OnInitCallback();
                SingletonLogUtil<T>.InstanceInit(_instance, _settings);
            }

            protected virtual void AddListener()
            {
            }

            protected virtual void RemoveListener()
            {
            }

            private static void SetSettings()
            {
                if (SettingsIsEmpty)
                {
                    _settings = SingletonSettingsUtil<T>.LoadSettingsByType();
                }
            }

            private static void NotAlive()
            {
                if (!_isAlive)
                {
                    _isAlive = false;
                }
            }

            private static void ClearInstance()
            {
                if (_instance != null)
                {
                    _instance = null;
                }
            }

            private static void ClearSettings()
            {
                if (!SettingsIsEmpty)
                {
                    _settings = null;
                }
            }

            public static T Instance
            {
                get
                {
                    lock (_lockObject)
                    {
                        SetSettings();
                        if (!_isAlive)
                        {
                            SingletonLogUtil<T>.InstanceAlreadyDestroyed(_settings);
                            return null;
                        }

                        if (InstanceIsEmpty)
                        {
                            var duplicates = SingletonDuplicateUtil<T>.FindDuplicate(_settings);
                            if (duplicates != null && duplicates.Length > 0)
                            {
                                _instance = SingletonDuplicateUtil<T>.DestroyAllButFirst(_settings, duplicates);
                            }

                            if (InstanceIsEmpty)
                            {
                                _instance = SingletonInstanceUtil<T>.InstanceObjectInScene(_settings);
                            }

                            _instance?.Init();
                        }

                        return _instance;
                    }
                }
            }

            private static bool SettingsIsEmpty
            {
                get
                {
                    return SingletonValidatorUtil.SettingsIsNull(_settings);
                }
            }

            private static bool InstanceIsEmpty
            {
                get
                {
                    return SingletonValidatorUtil.ObjectIsNull(_instance);
                }
            }

            public bool IsInitialized
            {
                get
                {
                    return _isInitialized;
                }
            }

            private bool InstanceIsThis
            {
                get
                {
                    return !InstanceIsEmpty && !ThisIsEmpty && _instance == this;
                }
            }

            private bool ThisIsEmpty
            {
                get
                {
                    return SingletonValidatorUtil.ObjectIsNull(this);
                }
            }
        }
    }
}