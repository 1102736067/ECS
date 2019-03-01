using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomTool
{
    [System.Serializable]
    public class AnimatorToolData : ScriptableObject
    {
        [SerializeField]
        public string AnimatorControllerPath;
        /// <summary>
        /// �����Help��״̬��
        /// </summary>
        [SerializeField]
        public List<AnimatorController> HelpControllers;
    }
}
