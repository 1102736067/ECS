using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface IInputService
    {
        void Init(Contexts contexts);
        void Update();
        void Up();
        void Down();
        void Left();
        void Right();
        /// <summary>
        /// ������������K��
        /// </summary>
        void AttackO();
        /// <summary>
        /// ������ ������L��
        /// </summary>
        void AttackX();
    }
    /// <summary>
    /// ��Entitas�������������
    /// </summary>
    public class EntitasInputService : IInputService
    {
        private Contexts _contexts;

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
            _contexts.input.SetGameInputButton(InputButton.NULL);
        }

        public void Update()
        {

        }

        public void AttackO()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.ATTACK_O);
        }

        public void AttackX()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.ATTACK_X);
        }

        public void Down()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.DOWN);
        }

        public void Left()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.LEFT);
        }

        public void Right()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.RIGHT);
        }

        public void Up()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.UP);
        }
    }

    /// <summary>
    /// ��Unity�������������
    /// </summary>
    public class UnityInputService : IInputService
    {
        private IInputService _entitaInputService;

        public void Init(Contexts contexts)
        {
            _entitaInputService = contexts.game.gameEntitasInputService.EntitasInputService;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Up();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Down();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Right();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AttackO();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                AttackX();
            }
        }

        public void Up()
        {
            _entitaInputService.Up();
        }

        public void Down()
        {
            _entitaInputService.Down();
        }

        public void Left()
        {
            _entitaInputService.Left();
        }

        public void Right()
        {
            _entitaInputService.Right();
        }

        public void AttackO()
        {
            _entitaInputService.AttackO();
        }

        public void AttackX()
        {
            _entitaInputService.AttackX();
        }
    }
}
