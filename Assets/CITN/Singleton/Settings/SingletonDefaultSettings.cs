using CITN.Singleton.Util;

namespace CITN
{
    namespace Singleton {

        namespace Settings
        {
            public class SingletonDefaultSettings<T> where T : Singleton<T>
            {
                private static SingletonSettings _settings = null;


                public static SingletonSettings Settings
                {
                    get
                    {
                        if (SingletonValidatorUtil.SettingsIsNull(_settings))
                        {
                            _settings = SingletonSettingsUtil<T>.LoadDefaultSettings();
                        }

                        return _settings;
                    }
                }
            }
        }
    }
}