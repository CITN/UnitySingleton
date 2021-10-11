using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Settings
        {
            [Serializable]
            public struct SingletonLogSettings
            {
                [SerializeField]
                [Tooltip("Show log messages")]
                private bool _log;
                [SerializeField]
                [Tooltip("Show warning messages")]
                private bool _logWarning;
                [SerializeField]
                [Tooltip("Show error messages")]
                private bool _logError;

                public SingletonLogSettings(bool log, bool logWarning, bool logError)
                {
                    _log = log;
                    _logWarning = logWarning;
                    _logError = logError;
                }

                public bool Log
                {
                    get
                    {
                        return _log;
                    }
                }

                public bool LogWarning
                {
                    get
                    {
                        return _logWarning;
                    }
                }
                public bool LogError
                {
                    get
                    {
                        return _logError;
                    }
                }
            }
        }
    }
}
