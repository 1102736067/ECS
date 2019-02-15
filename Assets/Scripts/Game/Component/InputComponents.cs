using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���밴��
    /// </summary>
    [Input, Unique]
    public class InputButtonComponent : IComponent
    {
        public InputButton InputButton;
        public InputState InputState;
    }

    /// <summary>
    /// �������＼�ܲ���
    /// </summary>
    [Input, Unique]
    public class InputHumanSkillState : IComponent
    {
        /// <summary>
        /// ����������������Ƿ����
        /// </summary>
        public bool IsEnd;
        /// <summary>
        /// ���ܱ���
        /// </summary>
        public int SkillCode;
    }
}
