using System;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Settings
        {
            [Serializable]
            public class SingletonDuplicateSettings
            {
                [SerializeField]
                [Tooltip("Which ones to look for?")]
                protected SingletonFindMode _findMode;
                [SerializeField]
                [Tooltip("Destroy what?")]
                protected SingletonDestroyMode _destroyMode;


                public SingletonDuplicateSettings()
                {
                    _findMode = SingletonFindMode.OnlyActiveObjects;
                    _destroyMode = SingletonDestroyMode.OnlyComponent;
                }


                public SingletonFindMode FindMode
                {
                    get
                    {
                        return _findMode;
                    }
                }

                public SingletonDestroyMode DestroyMode
                {
                    get
                    {
                        return _destroyMode;
                    }
                }
            }
        }
    }
}