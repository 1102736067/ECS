using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������ֽӿ�
    /// </summary>
    public interface IAni
    {
        void Play(int aniIndex);
    }

    public interface IPlayerAni : IAni,IPlayerBehaviour
    {

    }
}
