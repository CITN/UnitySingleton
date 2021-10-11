using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonValidatorUtil
            {
                public static bool ObjectIsNull<T>(Singleton<T> obj) where T : Singleton<T>
                {
                    return obj == null || GameObjectIsNull(obj.gameObject);
                }

                public static bool GameObjectIsNull(GameObject gameObject)
                {
                    return gameObject == null;
                }

                public static bool NeedShowLog(SingletonSettings settings)
                {
                    return !SettingsIsNull(settings) && settings.Debug.Log;
                }

                public static bool NeedShowLogWarning(SingletonSettings settings)
                {
                    return !SettingsIsNull(settings) && settings.Debug.LogWarning;
                }

                public static bool NeedShowLogError(SingletonSettings settings)
                {
                    return !SettingsIsNull(settings) && settings.Debug.LogError;
                }

                public static bool SettingsAssetIsNotValid(SingletonSettingsAsset asset)
                {
                    return asset == null || SettingsIsNull(asset.Settings);
                }

                public static bool SettingsIsNull(SingletonSettings settings)
                {
                    return settings == null;
                }
            }
        }
    }
}