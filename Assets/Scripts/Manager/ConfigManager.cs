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
        public T LoadJson<T>(string path)
        {
            string json = "";
            if (File.Exists(path))
            {
                json = File.ReadAllText(path);
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}
