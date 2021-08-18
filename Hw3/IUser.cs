namespace Hw3
{
    public interface IUser
    {
        //Как зовут пользователя
        public string Name { get; set; }

 
        public int DoMove(Game game);
    }
}