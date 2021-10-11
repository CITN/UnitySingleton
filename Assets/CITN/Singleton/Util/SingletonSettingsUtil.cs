using CITN.Singleton.Settings;
using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Util
        {
            public class SingletonSettingsUtil<T> where T : Singleton<T>
            {
                /// <summary>
                /// Load SingletonSettingsAsset by name. Name is typename + SingletonSettings
                /// SingletonSettingsAsset should be in Resources folder
                /// </summary>
                /// <returns>Settings from SingletonSettingsAsset</returns>
                public static SingletonSettings LoadSettingsByType()
                {
                    var name = string.Concat(typeof(T), SingletonConstant.SETTINGS_KEY_NAME);
                    var asset = Load(name);
                    if (SingletonValidatorUtil.SettingsAssetIsNotValid(asset))
                    {
                        return SingletonDefaultSettings<T>.Settings;
                    }

                    return asset.Settings;
                }


                /// <summary>
                /// Load SingletonSettingsAsset by name.
                /// SingletonSettingsAsset should be in Resources folder
                /// </summary>
                /// <param name="name"></param>
                /// <returns>
                /// return settings from SingletonSettingsAsset or 
                /// return new SingletonSsettings if SinglertonSettingsAsset not found
                ///  </returns>
                public static SingletonSettings LoadDefaultSettings(string name = SingletonConstant.DEFAULT_SETTINGS_FILE_NAME)
                {
                    var asset = Load(SingletonConstant.DEFAULT_SETTINGS_FILE_NAME);
                    if (SingletonValidatorUtil.SettingsAssetIsNotValid(asset))
                    {
                        return new SingletonSettings();
                    }

                    return asset.Settings;
                }

                /// <summary>
                /// Load SingletonSettingsAsset from Resources folder.
                /// </summary>
                /// <param name="fileName"></param>
                /// <returns>Can retrurn null if not found or fileName is null or empty</returns>
                private static SingletonSettingsAsset Load(string fileName)
                {
                    if (string.IsNullOrEmpty(fileName))
                    {
                        SingletonLogUtil<T>.FileNameIsNullOrEmpty();
                        return null;
                    }

                    var settings = Resources.Load<SingletonSettingsAsset>(fileName);
                    if (settings == null)
                    {
                        return null;
                    }

                    return settings;
                }

                private static void Unload(SingletonSettingsAsset asset)
                {
                    if (SingletonValidatorUtil.SettingsAssetIsNotValid(asset))
                    {
                        return;
                    }
                    Resources.UnloadAsset(asset);
                }
            }
        }
    }
}