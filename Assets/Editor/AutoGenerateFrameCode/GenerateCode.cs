using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// ���ɴ��벿��
    /// </summary>
    public class GenerateCode     
    {
        /// <summary>
        /// ��ServiceManager�в��봴����service���з����ʼ��
        /// </summary>
        public static void InitServices(string path)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                int index = content.IndexOf("IInitService[] services =");
                int newIndex = content.IndexOf("new", index);
                content = content.Insert(newIndex, "new " + ToolData.ServiceName + ToolData.ServicePostfix + "(),\r                ");
                File.WriteAllText(path, content, Encoding.UTF8);
            }
            else
            {
                Debug.LogError("Service�ű�������");
            }
        }

        /// <summary>
        /// �Ѵ�����ϵͳ��ӵ���ӦFeature�н��г�ʼ��
        /// </summary>
        /// <param name="contextName"></param>
        /// <param name="className"></param>
        /// <param name="systemName"></param>
        public static void InitSystem(string contextName, string className, params string[] systemName)
        {
            string path = "";
            switch (contextName)
            {
                case "Game":
                    path = ToolData.GameFeaturePath;
                    break;
                case "Input":
                    path = ToolData.InputFeaturePath;
                    break;
            }

            if (string.IsNullOrEmpty(path))
                return;

            foreach (string s in systemName)
            {
                SetSystem(path, s, className);
            }
        }

        /// <summary>
        /// �ѳ�ʼ�����ݲ��뵽��ӦFeature
        /// </summary>
        /// <param name="contextName"></param>
        /// <param name="className"></param>
        /// <param name="systemName"></param>
        private static void SetSystem(string path, string systemName, string className)
        {

            string content = File.ReadAllText(path);
            int index = content.IndexOf("void " + systemName + "Fun(Contexts contexts)");
            if (index < 0)
            {
                Debug.LogError("δ�ҵ���Ӧ������ϵͳ����" + systemName);
                return;
            }

            int startIndex = content.IndexOf("{", index);
            content = content.Insert(startIndex + 1, "\r            Add(new " + className + "(contexts));");
            File.WriteAllText(path, content, Encoding.UTF8);
        }

        /// <summary>
        /// �����ű�
        /// </summary>
        /// <param name="path"></param>
        /// <param name="className"></param>
        /// <param name="scriptContent"></param>
        public static void CreateScript(string path, string className, string scriptContent)
        {
            if (Directory.Exists(path))
            {
                File.WriteAllText(path + "/" + className + ".cs", scriptContent, Encoding.UTF8);
            }
            else
            {
                Debug.LogError("Ŀ¼:" + path + "������");
            }

            AssetDatabase.Refresh();
        }
    }
}
