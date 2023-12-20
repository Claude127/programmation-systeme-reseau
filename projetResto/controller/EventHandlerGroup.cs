using System.Threading;
using projetResto.model;

namespace projetResto.controller;

public class EventHandlerGroup
{
    
        private static EventHandlerGroup instance;

        private EventHandlerGroup() { }

        public static EventHandlerGroup Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventHandlerGroup();
                return instance;
            }
        }

        public void Update(GroupClient group)
        {
            switch (group.State)
            {
                case GroupState.WaitPlate:
                    SalleCommandsController.ConnectAndSendCommand(group);

                    break;
                case GroupState.WaitDessert:
                    SalleCommandsController.ConnectAndSendCommand(group);

                    break;
            }
        }

        private void UpdateCallBack()
        {
            Thread.Sleep(2000);
        }
    
        
}