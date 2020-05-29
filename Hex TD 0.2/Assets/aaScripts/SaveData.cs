

[System.Serializable]
public class SaveData 
{
    public int money;
   public SaveData (PlayerStats save) //This is a constructor, it initializes objects of a class
                                      // this one in particular is parameterized
    {
        money = PlayerStats.money;
    }
}
