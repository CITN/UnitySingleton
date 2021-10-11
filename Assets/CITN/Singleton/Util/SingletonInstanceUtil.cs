using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonInstanceUtil<T> where T : Singleton<T>
            {
                public static T InstanceObjectInScene(SingletonSettings settings) 
                {
                    if (SingletonValidatorUtil.SettingsIsNull(settings))
                    {
                        return null;
                    }

                    if (!settings.InstanceObjectInScene)
                    {
                        return null;
                    }

                    var singletonObject = new GameObject(string.Concat(typeof(T), " (Singleton)"));
                    return singletonObject.AddComponent<T>();
                }
            }
        }
    }
}