using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Service
{
    /// <summary>
    /// ���ҷ������
    /// </summary>
    [Service,Unique]
    public class FindObjectServiceComponent : IComponent
    {
        public IFindObjectService FindObjectService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Service, Unique]
    public class EntitasInputServiceComponent : IComponent
    {
        public IInputService EntitasInputService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Service, Unique]
    public class LogServiceComponent : IComponent
    {
        public ILogService LogService;
    }

    /// <summary>
    /// ����������
    /// </summary>
    [Service, Unique]
    public class LoadServiceComponent : IComponent
    {
        public ILoadService LoadService;
    }

    [Service, Unique]
    public class TimerServiceComponent : IComponent
    {
        public ITimerService TimerService;
    }

    [Service, Unique]
    public class SkillCodeServiceComponent : IComponent
    {
        public ISkillCodeService SkillCodeService;
    }
}
