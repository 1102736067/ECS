using System.IO;
using Game;
using UIFrame;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// ���ù�����
    /// </summary>
    public class ConfigManager : SingletonBase<ConfigManager>
    {
        /// <summary>
        /// ����json�����ļ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T LoadJson<T>()
        {
            string json = "";
            if (File.Exists(ConfigPath.PLAYER_CONFIG))
            {
                json = File.ReadAllText(ConfigPath.PLAYER_CONFIG);
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}
