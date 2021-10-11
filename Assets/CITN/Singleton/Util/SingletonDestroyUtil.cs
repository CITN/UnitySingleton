using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonDestroyUtil<T> where T : Singleton<T>
            {
                public static void Destroy(Singleton<T> instance, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.SettingsIsNull(settings))
                    {
                        SingletonLogUtil<T>.SettingsForDestroyIsNull();
                        return;
                    }

                    if (SingletonValidatorUtil.ObjectIsNull(instance))
                    {
                        return;
                    }

                    switch (settings.Duplicate.DestroyMode)
                    {
                        case SingletonDestroyMode.OnlyComponent:
                            DestroySingletonComponent(instance.gameObject, settings);
                            break;
                        case SingletonDestroyMode.GameObject:
                            DestroySingletonGameObject(instance.gameObject, settings);
                            break;
                    }
                }

                private static void DestroySingletonComponent(GameObject gameObject, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.GameObjectIsNull(gameObject))
                    {
                        return;
                    }

                    var component = gameObject.GetComponent(typeof(T));
                    if (component == null)
                    {
                        return;
                    }
                    SingletonLogUtil<T>.DestroyComponent(component.gameObject.name, settings);
                    GameObject.Destroy(component);

                }

                private static void DestroySingletonGameObject(GameObject gameObject, SingletonSettings settings)
                {
                    if (SingletonValidatorUtil.GameObjectIsNull(gameObject))
                    {
                        return;
                    }
                    SingletonLogUtil<T>.DestroyGameObject(gameObject.name, settings);
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }
}