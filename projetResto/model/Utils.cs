namespace projetResto.model;

public enum UtilsState
{
    Available,
    InUse,
    Dirty,
};

public class Utils
{
    
    
        public UtilsState state;

        public UtilsState State
        {
            get => state;
            set => state = value;
        }

        public Utils()
        {
            this.State = UtilsState.Available;
        }
    
}