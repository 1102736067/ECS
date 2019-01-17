using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������״̬����
    /// </summary>
    public enum CameraAniName
    {
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
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK_O,
        ATTACK_X
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
}
