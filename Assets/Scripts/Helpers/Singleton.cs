using UnityEngine;

namespace Helpers
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                _instance ??= FindFirstObjectByType<T>();
                return _instance;
            }
        }
    }
}

