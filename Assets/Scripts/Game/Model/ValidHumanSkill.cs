using UnityEngine;

namespace Game.Model
{
    /// <summary>
    /// ��Ч�ļ�������
    /// </summary>
    public class ValidHumanSkill      
    {
        public ValidHumanSkill(int code)
        {
            Code = code;
        }

        public int Code { get; private set; }
    }
}
