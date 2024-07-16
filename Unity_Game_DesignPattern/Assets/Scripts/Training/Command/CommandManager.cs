using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Command{

   public class CommandManager : MonoBehaviourSingleton<CommandManager>
    {
        public Action OnCommandsExecute;
        public CommandSprites commandSprites;

        [SerializeField] private Button executeCommandsButton;
        [SerializeField] private Button undoCommandButton;
        [SerializeField] private Transform commandsListParent;
        [SerializeField] private Transform commandPrefab;
        [SerializeField] private float commandTime = 1;

        private Queue<ICommand> commandsQueue = new Queue<ICommand>();

        private void OnEnable()
        {
            executeCommandsButton.onClick.AddListener(ExecuteCommands);
            undoCommandButton.onClick.AddListener(UndoLastCommand);
        }

        public void AddCommand(ICommand command)
        {
            commandsQueue.Enqueue(command);

            Transform instantiatedCommand = Instantiate(commandPrefab, commandsListParent);
            SetCommandSprite(instantiatedCommand, command);
        }

        public void UndoLastCommand()
        {
            if (commandsQueue.TryDequeue(out ICommand command))
            {
                Destroy(commandsListParent.GetChild(commandsListParent.childCount - 1).gameObject);
            }
        }

        public async void ExecuteCommands()
        {
            OnCommandsExecute?.Invoke();

            while (commandsQueue.Count > 0)
            {
                ICommand command = commandsQueue.Dequeue();
                command.Execute();
                Destroy(commandsListParent.GetChild(0).gameObject);
                await Task.Delay((int)(commandTime * 1000));
            }
        }

        private void SetCommandSprite(Transform instantiatedCommand, ICommand command)
        {
            Image commandImage = instantiatedCommand.GetChild(1).GetComponent<Image>();
            commandImage.sprite = command.GetSprite();
        }
    }

    [System.Serializable]
    public class CommandSprites
    {
        public Sprite moveUp;
        public Sprite moveDown;
        public Sprite moveLeft;
        public Sprite moveRight;
        public Sprite attack;
    }



}


