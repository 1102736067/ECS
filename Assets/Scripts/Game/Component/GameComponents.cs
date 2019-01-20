using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// �������״̬ ���ݴ�״̬�ĸı䲥���������
    /// </summary>
    [Game,Event(EventTarget.Self),Unique]
    public class CameraState : IComponent
    {
        public CameraAniName State;
    }

    /// <summary>
    /// ��Ϸ״̬
    /// </summary>
    [Game,Unique]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }

    /// <summary>
    /// ���
    /// </summary>
    [Game,Unique]
    public class PlayerComponent : IComponent
    {
        public IView Player;
        public IPlayerBehaviour Behaviour;
        public IPlayerAni Ani;
    }

    /// <summary>
    /// ��Ҷ���
    /// </summary>
    [Game]
    public class PlayerAniState : IComponent
    {
        public PlayerAniIndex AniIndex;
    }
 
}
