using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonDuplicateUtil<T> where T : Singleton<T>
            {
                public static T[] FindDuplicate(SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.SettingsIsNull(settings))
                    {
                        return null;
                    }

                    switch (settings.Duplicate.FindMode)
                    {
                        case SingletonFindMode.All:
                            return Resources.FindObjectsOfTypeAll<T>();
                        case SingletonFindMode.OnlyActiveObjects:
                            return GameObject.FindObjectsOfType<T>();
                        default:
                            return null;
                    }
                }

                public static T DestroyAllButFirst(SingletonSettings settings, params T[] items)
                {
                    if (items == null)
                    {
                        return null;
                    }

                    if (items.Length == 1)
                    {
                        return items[0];
                    }

                    T first = null;
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (SingletonValidatorUtil.ObjectIsNull(items[i]))
                        {
                            continue;
                        }
                        
                        if (SingletonValidatorUtil.ObjectIsNull(first))
                        {
                            first = items[i];
                            continue;
                        }

                        SingletonLogUtil<T>.HaveDuplicate(items[i].gameObject.name, settings);
                        SingletonDestroyUtil<T>.Destroy(items[i], settings);
                    }

                    return first;
                }
            }
        }
    }
}