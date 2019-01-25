using System.Collections.Generic;
using System.IO;
using System.Linq;
using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Plugins;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// ����������
    /// </summary>
    public class ToolData      
    {
        /// <summary>
        /// view�ű����·��
        /// </summary>
        public static string ViewPath;
        /// <summary>
        /// service�ű����·��
        /// </summary>
        public static string ServicePath;
        /// <summary>
        /// serviceManager�ű�·��
        /// </summary>
        public static string ServiceManagerPath;
        /// <summary>
        /// ϵͳ�ű����·��
        /// </summary>
        public static string SystemPath;
        /// <summary>
        /// ����־û����ݻ���·��
        /// </summary>
        public static string DataPah = "Assets/Editor/AutoGenerateFrameCode/Data/";
        /// <summary>
        /// ����־û������ļ�����
        /// </summary>
        public static string DataFileName = "Data.asset";
        /// <summary>
        /// View��ű���׺
        /// </summary>
        public static string ViewPostfix = "View";
        /// <summary>
        /// �û������View��ű�����
        /// </summary>
        public static string ViewName;
        /// <summary>
        /// Service��ű���׺
        /// </summary>
        public static string ServicePostfix = "Service";
        /// <summary>
        /// �û������Service��ű�����
        /// </summary>
        public static string ServiceName;
        /// <summary>
        /// System��ű���׺
        /// </summary>
        public static string SystemPostfix = "System";
        /// <summary>
        /// �������Ӧϵͳ�ű�����
        /// </summary>
        public static string ReactiveSystemName;
        /// <summary>
        /// ���������ռ�
        /// </summary>
        public static string NamespaceBase = "Game";
        /// <summary>
        /// ��ǰ���е�����������
        /// </summary>
        public static string[] ContextNames;
        /// <summary>
        /// ÿ�������ĵ�ѡ��״̬ key������������ value���Ƿ�ѡ��trueΪѡ�У�
        /// </summary>
        public static Dictionary<string, bool> ContextSelectedState;
        /// <summary>
        /// ��ǰѡ������������
        /// </summary>
        public static string SelectedContextName;

        /// <summary>
        /// ViewFeature�ű�·��
        /// </summary>
        public static string ViewFeaturePath;
        /// <summary>
        ///  InputFeature�ű�·��
        /// </summary>
        public static string InputFeaturePath;
        /// <summary>
        ///  GameFeature�ű�·��
        /// </summary>
        public static string GameFeaturePath;

        /// <summary>
        /// ����ϵͳ���������
        /// </summary>
        public static string OtherSystemName;
        /// <summary>
        /// ����ϵͳ�ӿ���������
        /// </summary>
        public static string[] SystemInterfaceName =
        {
            "IInitializeSystem",
            "IExecuteSystem",
            "ICleanupSystem",
            "ITearDownSystem"
        };
        /// <summary>
        /// ϵͳѡ��״̬���� key��ϵͳ���� value���Ƿ�ѡ��trueΪѡ�У�
        /// </summary>
        public static Dictionary<string, bool> SystemSelectedState;

        public static void Init()
        {
            GetContextName();
            ReadDataFromLocal();
            InitContextSelectedState();
            SelectedContextName = ContextNames[0];
            InitSystemSelectedState();
        }

        private static void InitContextSelectedState()
        {
            ContextSelectedState = new Dictionary<string, bool>();

            ResetContextSelectedState();
        }

        private static void InitSystemSelectedState()
        {
            SystemSelectedState = new Dictionary<string, bool>();
            foreach (string system in SystemInterfaceName)
            {
                SystemSelectedState[system] = false;
            }
        }

        public static void ResetContextSelectedState()
        {
            foreach (string contextName in ContextNames)
            {
                ContextSelectedState[contextName] = false;
            }
        }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        private static void GetContextName()
        {
            var provider = new ContextDataProvider();
            provider.Configure(Preferences.sharedInstance);
            var data = (ContextData[])provider.GetData();
            ContextNames = data.Select(u => u.GetContextName()).ToArray();
        }

        //�������ݵ�����
        public static void SaveDataToLocal()
        {
            Directory.CreateDirectory(DataPah);
            EntitasData data = new EntitasData();
            data.ViewPath = ViewPath;
            data.ServicePath = ServicePath;
            data.SystemPath = SystemPath;
            data.ServiceManagerPath = ServiceManagerPath;
            data.GameFeaturePath = GameFeaturePath;
            data.InputFeaturePath = InputFeaturePath;
            data.ViewFeaturePath = ViewFeaturePath;
            AssetDatabase.CreateAsset(data, DataPah + DataFileName);
        }

        //�ӱ��ض�ȡ����
        private static void ReadDataFromLocal()
        {
            EntitasData data = AssetDatabase.LoadAssetAtPath<EntitasData>(DataPah + DataFileName);
            if (data != null)
            {
                ViewPath = data.ViewPath;
                ServicePath = data.ServicePath;
                SystemPath = data.SystemPath;
                ServiceManagerPath = data.ServiceManagerPath;
                GameFeaturePath = data.GameFeaturePath;
                InputFeaturePath = data.InputFeaturePath;
                ViewFeaturePath = data.ViewFeaturePath;
            }
        }
    }
}
