namespace Logic
{
    public class Player
    {
        private string m_PlayerName;
        private int m_AmountOfPairsFound = 0;

        public Player(string i_Name)
        {
            m_PlayerName = i_Name;
        }

        public string GetName 
        {
            get { return this.m_PlayerName; } 
        }

        public int GetScore 
        {
            get { return m_AmountOfPairsFound; }
        }

        public void UpdateScore()
        {
            m_AmountOfPairsFound++;
        }
    }
}
