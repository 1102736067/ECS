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

    [Input, Unique]
    public class InputValidHumanSkill : IComponent
    {
        /// <summary>
        /// ������������Ƿ���Ч
        /// </summary>
        public bool IsValid;

        public int SkillCode;
    }
}
