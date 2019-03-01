using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// ��animator���ж��η�װ����չ����
    /// </summary>
    public static class AnimatorUtil     
    {
        /// <summary>
        /// ��ȡ��ǰ�㼶����״̬
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorState[] GetAnimatorState(this Animator ani, int layer)
        {
            var machine = ani.GetAnimatorStateMachine(layer);
            return machine.GetAnimatorState();
        }


        /// <summary>
        /// ��ȡ��ǰ�㼶����״̬
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorState[] GetAnimatorState(this AnimatorController ani, int layer)
        {
            var machine = ani.GetAnimatorStateMachine(layer);
            return machine.GetAnimatorState();
        }

        /// <summary>
        /// ��ȡ��ǰanimator��Ӧ�㼶��״̬��
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine GetAnimatorStateMachine(this Animator ani,int layer)
        {
            AnimatorController aniController = ani.runtimeAnimatorController as AnimatorController;
            return aniController.layers[layer].stateMachine;
        }

        /// <summary>
        /// ��ȡ��ǰanimator��Ӧ�㼶��״̬��
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine GetAnimatorStateMachine(this AnimatorController ani, int layer)
        {
            return ani.layers[layer].stateMachine;
        }

        /// <summary>
        /// ��ȡ��״̬��ʼ����
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="baseLayer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine[] GetSubStateMachines(this Animator ani, int baseLayer)
        {
            var baseMachine = ani.GetAnimatorStateMachine(baseLayer);
            return baseMachine.stateMachines.Select(u=>u.stateMachine).ToArray();
        }


        /// <summary>
        /// ��ȡ��״̬��ʼ����
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="baseLayer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine[] GetSubStateMachines(this AnimatorController ani, int baseLayer)
        {
            var baseMachine = ani.GetAnimatorStateMachine(baseLayer);
            return baseMachine.stateMachines.Select(u => u.stateMachine).ToArray();
        }

        /// <summary>
        /// ��ȡ��ǰ״̬������״̬
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public static AnimatorState[] GetAnimatorState(this AnimatorStateMachine machine)
        {
            return machine.states.Select(u => u.state).ToArray();
        }

        /// <summary>
        /// ͨ����״̬�����ƻ�ȡ��״̬��
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="baseLayer"></param>
        /// <param name="stateMachineName"></param>
        /// <returns></returns>
        public static AnimatorStateMachine GetSubStateMachine(this Animator ani, int baseLayer, string stateMachineName)
        {
            var machines = ani.GetSubStateMachines(baseLayer);
            AnimatorStateMachine machine = machines.FirstOrDefault(u => u.name == stateMachineName);
            if (machine == null)
            {
                Debug.LogError("δ�ҵ�����Ϊ"+ stateMachineName+"����״̬��");
            }
            return machine;
        }

        /// <summary>
        /// �Ƴ���ǰ�����еĹ���״̬
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        public static void RemoveAllTrasition(this Animator ani, int layer)
        {
            var states = ani.GetAnimatorState(layer);
            foreach (AnimatorState state in states)
            {
                state.RemoveStateAllTrasition();
            }
        }

        /// <summary>
        /// �Ƴ�ָ��״̬�����й���״̬
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="state"></param>
        public static void RemoveStateAllTrasition(this AnimatorState state)
        {
            foreach (AnimatorStateTransition transition in state.transitions)
            {
                state.RemoveTransition(transition);
            }
        }

        /// <summary>
        /// ͨ��Ŀ��״̬�����ƹ�ϣֵ��ȡ����״̬
        /// </summary>
        /// <param name="state"></param>
        /// <param name="targetNameHash"></param>
        /// <returns></returns>
        public static AnimatorStateTransition GetTransition(this AnimatorState state,int targetNameHash)
        {
            var transition = state.transitions.FirstOrDefault(u => u.destinationState.nameHash == targetNameHash);
            if (transition == null)
            {
                Debug.LogError("�޷��ҵ�NameHashΪ" + targetNameHash + "��״̬");
            }
            return transition;
        }

        /// <summary>
        /// ��ȡ��ǰ״̬��������״̬
        /// </summary>
        /// <param name="ani"></param>
        public static void GetAllAnimatorStates(this Animator ani)
        {
            AnimatorController aniController = ani.runtimeAnimatorController as AnimatorController;
            aniController.GetAllAnimatorStates();
        }

        /// <summary>
        /// ��ȡ��ǰ״̬��������״̬
        /// </summary>
        /// <param name="ani"></param>
        public static List<AnimatorState> GetAllAnimatorStates(this AnimatorController ani)
        {
            List<AnimatorState> states = new List<AnimatorState>();
            for (int i = 0; i < ani.layers.Length; i++)
            {
                states.AddRange(AddInLayer(ani, i));
            }

            return states;
        }

        private static List<AnimatorState> AddInLayer(AnimatorController controller, int layer)
        {
            List<AnimatorState> states = new List<AnimatorState>();
            var statesInLayer = controller.GetAnimatorState(layer);
            var statesInMachine = AddInSubMachine(controller, layer);

            states.AddRange(statesInLayer);
            states.AddRange(statesInMachine);

            return states;
        }

        private static List<AnimatorState> AddInSubMachine(AnimatorController controller, int layer)
        {
            List<AnimatorState> states = new List<AnimatorState>();
            var machines = controller.GetSubStateMachines(layer);
            foreach (AnimatorStateMachine machine in machines)
            {
                states.AddRange(machine.GetAnimatorState());
            }

            return states;
        }
    }
}
