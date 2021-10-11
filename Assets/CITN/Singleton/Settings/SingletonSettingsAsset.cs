using UnityEngine;

namespace CITN
{
    namespace Singleton
    {
        namespace Settings
        {
            [CreateAssetMenu(fileName = SingletonConstant.DEFAULT_SETTINGS_FILE_NAME,
                         menuName = SingletonConstant.MENU_NAME,
                         order = SingletonConstant.ORDER_ASSET_MENU)]
            public class SingletonSettingsAsset : ScriptableObject
            {
                [SerializeField]
                protected SingletonSettings _settings;

                public SingletonSettings Settings
                {
                    get
                    {
                        return _settings;
                    }
                }
            }
        }
    }
}