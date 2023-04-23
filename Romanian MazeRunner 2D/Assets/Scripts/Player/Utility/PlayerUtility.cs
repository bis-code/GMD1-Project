namespace DefaultNamespace
{
    public class PlayerUtility
    {
        private static PlayerUtility instance;

        
        
        
        
        public static PlayerUtility GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerUtility();
            }

            return instance;
        }
    }
}