using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Service;
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
    public class EntitasInputServiceComponent : IComponent
    {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Game, Unique]
    public class LogServiceComponent : IComponent
    {
        public ILogService LogService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Game, Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService LoadService;
    }

    [Game,Unique]
    public class TimerServiceComponent : IComponent
    {
        public ITimerService TimerService;
    }
}
