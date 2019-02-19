using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������״̬����
    /// </summary>
    public enum CameraAniName
    {
        NULL,
        /// <summary>
        /// �����������
        /// </summary>
        START_GAME_ANI
    }

    /// <summary>
    /// ���������
    /// </summary>
    public enum CameraParent
    {
        START,
        IN_GAME
    }

    /// <summary>
    /// �ؿ�ID
    /// </summary>
    public enum LevelID
    {
        ONE =1,
        TWO
    }

    /// <summary>
    /// �ؿ�����ID
    /// </summary>
    public enum LevelPartID
    {
        ONE = 1,
        TWO
    }

    /// <summary>
    /// ���밴ť
    /// </summary>
    public enum InputButton
    {
        NULL,
        FORWARD,
        BACK,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X
    }

    /// <summary>
    /// ���밴���İ���״̬
    /// </summary>
    public enum InputState
    {
        NULL,
        DOWN,
        PREE,
        UP  
    }

    /// <summary>
    /// ��Ϸ״̬
    /// </summary>
    public enum GameState
    {
        START,
        PAUSE,
        END
    }

    /// <summary>
    /// ��������AniIndex��Ӧö��
    /// </summary>
    public enum PlayerAniIndex
    {
        IDLE,
        RUN,
        WALK
    }

    /// <summary>
    /// ������Ϊ
    /// </summary>
    public enum PlayerBehaviourIndex
    {
        IDLE,
        RUN,
        WALK,
        ATTACK
    }

    /// <summary>
    /// ״̬������Ϊ״̬
    /// </summary>
    public enum BehaviorState
    {
        ENTER,
        UPDATE,
        EXIT
    }

    /// <summary>
    /// ��ʱ����ʶ
    /// </summary>
    public enum TimerId
    {
        MOVE_TIMER,
        /// <summary>
        /// �ж����＼���Ƿ���Ч��ʱ��
        /// </summary>
        JUDGE_SKILL_TIMER
    }


}
