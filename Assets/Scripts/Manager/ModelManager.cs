using Game;
using Manager;
using Model;
using UIFrame;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// ����ģ�͹�����
    /// </summary>
    public class ModelManager : SingletonBase<ModelManager>
    {
        /// <summary>
        /// �������������
        /// </summary>
        public PlayerDataModel PlayerData { get; private set; }

        public HumanSkillModel HumanSkillModel { get; private set; }

        public EnemyModel EnemyModel { get; private set; }

        public SpawnEnemyModel SpawnEnemyModel { get; private set; }

        public void Init()
        {
            PlayerData = ConfigManager.Single.LoadJson<PlayerDataModel>(ConfigPath.PLAYER_CONFIG);
            HumanSkillModel = ConfigManager.Single.LoadJson<HumanSkillModel>(ConfigPath.HUMAN_SKILL_CONFIG);
            EnemyModel = ConfigManager.Single.LoadJson<EnemyModel>(ConfigPath.ENEMY_CONFIG);
            SpawnEnemyModel = ConfigManager.Single.LoadJson<SpawnEnemyModel>(ConfigPath.SPAWN_ENEMY_CONFIG);
        }
    }
}
