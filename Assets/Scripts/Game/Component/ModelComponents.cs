using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Model
{
    [Game,Unique]
    public class HumanSkillConfig : IComponent
    {
        public List<ValidHumanSkill> ValidHumanSkills;
        /// <summary>
        /// ��ǰ��Ч�������󳤶�
        /// </summary>
        public int LengthMax;
    }
}
