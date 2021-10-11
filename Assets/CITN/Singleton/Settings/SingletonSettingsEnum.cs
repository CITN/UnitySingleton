using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Settings
        {
            public enum SingletonDestroyMode
            {
                [Tooltip("Don't use destroy at all")]
                None = 0,
                [Tooltip("Destroy only component")]
                OnlyComponent = 1,
                [Tooltip("Destroy gameObject")]
                GameObject = 2
            }

            public enum SingletonFindMode
            {
                [Tooltip("Don't use search at all")]
                None = 0,
                [Tooltip("Find only aactive objects")]
                OnlyActiveObjects = 1,
                [Tooltip("Find all objects")]
                All = 2
            }
        }
    }
}