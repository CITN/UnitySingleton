using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonLogUtil<T> where T : Singleton<T>
            {
                public static void InstanceAlreadyDestroyed(SingletonSettings settings)
                {
                    LogError($"[Singleton] Instance already destroyed. Returning null.", settings);
                }

                public static void InstanceInit(T instance, SingletonSettings settings)
                {
                    string name = !SingletonValidatorUtil.ObjectIsNull(instance) ? instance.gameObject.name : string.Empty;
                    Log($"CurrentInstance = \"{name}\" is Init", settings);
                }

                public static void FileNameIsNullOrEmpty()
                {
                    LogWarning($"Load settings. File name is null or empty");
                }

                public static void FileNotFound(string fileName)
                {
                    LogWarning($"Load settings. \"{fileName}\" not found");
                }

                public static void HaveDuplicate(string name, SingletonSettings settings)
                {
                    LogWarning($"Have more that one in scene. \"{name}\"", settings);
                }

                public static void DestroyComponent(string name, SingletonSettings settings)
                {
                    Log($"DestroyComponent: \"{name}\"", settings);
                }

                public static void DestroyGameObject(string name, SingletonSettings settings)
                {
                    Log($"DestroyGameObject: \"{name}\"", settings);
                }

                public static void SettingsForDestroyIsNull()
                {
                    LogWarning("Settings for destroy is null");
                }

                public static void Log(string message, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.NeedShowLog(settings))
                    {
                        Debug.Log($"{GetLogTitle} {message}");
                    }
                }

                public static void LogWarning(string message, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.NeedShowLogWarning(settings))
                    {
                        LogWarning(message);
                    }
                }

                public static void LogWarning(string message)
                {
                    Debug.LogWarning($"{GetLogTitle} {message}");
                }

                public static void LogError(string message, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.NeedShowLogError(settings))
                    {
                        Debug.LogError($"{GetLogTitle} {message}");
                    }
                }

                private static string GetLogTitle
                {
                    get
                    {
                        return $"{SingletonConstant.LOG_TITLE}.{typeof(T)} |";
                    }
                }
            }
        }
    }
}