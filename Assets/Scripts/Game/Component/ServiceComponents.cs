using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���ҷ������
    /// </summary>
    [Game,Unique]
    public class FindObjectServiceComponent : IComponent
    {
        public IFindObjectService FindObjectService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Game, Unique]
    public class InputServiceComponent : IComponent
    {
        public IInputService InputService;
    }
}
