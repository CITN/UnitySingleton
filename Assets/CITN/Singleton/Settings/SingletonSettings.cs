using System;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Settings
        {
            [Serializable]
            public class SingletonSettings
            {
                [SerializeField]
                [Tooltip("Show debug messages")]
                protected SingletonLogSettings _debug;

                [Space(8)]
                [SerializeField]
                [Tooltip("Instance new object. If there is nothing on scene")]
                protected bool _instanceObjectInScene;
                [SerializeField]
                [Tooltip("gameObject.SetActive(false)")]
                protected bool _deactivateOnLoad;
                [SerializeField]
                [Tooltip("Do not destroy the target Object when loading a new Scene.")]
                protected bool _dontDestroyOnLoadScene;

                [Space(8)]
                [SerializeField]
                [Tooltip("When multiple objects in scene")]
                protected SingletonDuplicateSettings _duplicate;


                public SingletonSettings()
                {
                    _debug = new SingletonLogSettings(false, true, true);
                    _instanceObjectInScene = false;
                    _deactivateOnLoad = false;
                    _dontDestroyOnLoadScene = true;
                    _duplicate = new SingletonDuplicateSettings();
                }


                public SingletonLogSettings Debug
                {
                    get
                    {
                        return _debug;
                    }
                }

                public bool InstanceObjectInScene
                {
                    get
                    {
                        return _instanceObjectInScene;
                    }
                }

                public bool DeactivateOnLoad
                {
                    get
                    {
                        return _deactivateOnLoad;
                    }
                }

                public bool DontDestroyOnLoadScene
                {
                    get
                    {
                        return _dontDestroyOnLoadScene;
                    }
                }

                public SingletonDuplicateSettings Duplicate
                {
                    get
                    {
                        return _duplicate;
                    }
                }
            }
        }
    }
}