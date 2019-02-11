using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomTool
{
    public class GenerateController
    {
        public static void SelectedAni()
        {
            Object[] _objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Unfiltered);
            if (_objs.Length == 0)
            {
                Debug.Log("��û��ѡ���κ����壡");
                return;
            }
            for (int i = 0; i < _objs.Length; i++)
            {
                if (!Directory.Exists(Application.dataPath + "/" + GenerateControllerWindow.OutputPath))
                {
                    Directory.CreateDirectory(Application.dataPath + "/" + GenerateControllerWindow.OutputPath);
                }
                GameObject _temObJ = _objs[i] as GameObject;
                string _outputPath = "";
                if (string.IsNullOrEmpty(GenerateControllerWindow.OutputPath))
                {
                    _outputPath = "Assets/";
                }
                else
                {
                    _outputPath = "Assets/" + GenerateControllerWindow.OutputPath + "/";
                }

                if (GenerateControllerWindow.IsCreateAnimatorController)
                {
                   CreateAnimatorController(AssetDatabase.GetAssetPath(_objs[i]), _temObJ.name + ".controller", _outputPath + "AnimatorControllers");
                }
            }
            AssetDatabase.Refresh();
        }
        private static AnimatorController CreateAnimatorController(string _assetsPath, string _controllerName, string _outPutPath)
        {
            //����AnimatorController�ļ���������_outPutPath·����
            if (!Directory.Exists(_outPutPath))
            {
                Directory.CreateDirectory(_outPutPath);
            }

            //���ɶ�����������AnimatorController��
            AnimatorController _animatorController = AnimatorController.CreateAnimatorControllerAtPath(_outPutPath + "/" + _controllerName);

            //��Ӳ�����parameters��
            _animatorController.AddParameter("Normal", AnimatorControllerParameterType.Float);
            _animatorController.AddParameter("Play", AnimatorControllerParameterType.Bool);

            //�õ�����Layer�� Ĭ��layerΪbase,������չ
            AnimatorControllerLayer _layer = _animatorController.layers[0];

            //�Ѷ����ļ����������Ǵ�����AnimatorController��
            AddStateTransition(_assetsPath, _layer);
            return _animatorController;
        }
        private static void AddStateTransition(string _assetsPath, AnimatorControllerLayer _layer)
        {
            //��Ӷ���״̬��������ֻ��ͨ����õ���״̬������δ��ӣ�
            AnimatorStateMachine _stateMachine = _layer.stateMachine;

            // ���ݶ����ļ���ȡ����AnimationClip����
            var _datas = AssetDatabase.LoadAllAssetsAtPath(_assetsPath);
            if (_datas.Length == 0)
            {
                Debug.Log(string.Format("Can't find clip in {0}", _assetsPath));
                return;
            }

            // ������ȡģ���а����Ķ���Ƭ��
            foreach (var _data in _datas)
            {
                if (!(_data is AnimationClip))
                {
                    continue;
                }
                AnimationClip _newClip = _data as AnimationClip;
                AddAnimationClip(_stateMachine, _newClip);
            }

            // �����һ��Ĭ�ϵĿ�״̬
            AnimatorState _emptyState = _stateMachine.AddState("Empty", new Vector3(_stateMachine.entryPosition.x + 200, _stateMachine.entryPosition.y, 0));
        }

        private static void AddAnimationClip(AnimatorStateMachine _stateMachine,AnimationClip clip)
        {
            // ����붯�����ƶ�Ӧ��װ̬��AnimatorState����״̬���У�AnimatorStateMachine���У�������״̬
            AnimatorState _startState = _stateMachine.AddState(clip.name, new Vector3(_stateMachine.entryPosition.x + 500, _stateMachine.entryPosition.y + 100, 0));
            _startState.motion = clip;

            

            //_animatorStateTransition.AddCondition(AnimatorConditionMode.If, 0, "BoolParameter"); ΪTrue
            //_animatorStateTransition.AddCondition(AnimatorConditionMode.IfNot, 0, "BoolParameter"); ΪFalse
        }
        //����Any״̬�����ӣ�ֻ����any������������״̬��������any��
        private static void SetAnyTransition(AnimatorStateMachine _stateMachine,AnimatorState to, TransitionData[] datas)
        {
            AnimatorStateTransition transition = _stateMachine.AddAnyStateTransition(to);
            SetTransitionData(transition, datas);
        }

        //��������״̬������
        private static void SetTransition(AnimatorState from, AnimatorState to, TransitionData[] datas)
        {
            AnimatorStateTransition transition = from.AddTransition(to);
            SetTransitionData(transition,datas);
        }
        //������������
        private static void SetTransitionData(AnimatorStateTransition transition,TransitionData[] datas)
        {
            foreach (TransitionData data in datas)
            {
                transition.AddCondition(data.ConditionMode, data.ConditionValue, data.ParaName);
                transition.hasExitTime = data.HasExitTime;
            }
        }
    }

    /// <summary>
    /// ����״̬��������
    /// </summary>
    public struct TransitionData
    {
        /// <summary>
        /// ����ģʽ
        /// <para>If--------bool������Ϊtrue��������</para>
        /// <para>IfNot-----bool������Ϊfalse��������</para>
        /// <para>�����ľ��������ıȽ���ֵ</para>
        /// </summary>
        public AnimatorConditionMode ConditionMode;
        public float ConditionValue;
        public string ParaName;
        public bool HasExitTime;
    }
}
