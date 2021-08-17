namespace Hw3
{
    public interface IUser
    {
        //Как зовут пользователя
        public string Name { get; set; }

        /// <summary>
        /// Игрок делает ход
        /// Даем знать игроку всю необходимую информацию
        /// </summary>
        /// <param name="gameNumber"></param>
        /// <param name="minNumber"></param>
        /// <param name="maxNumber"></param>
        /// <returns>Возвращается выбранное число</returns>
        public int DoMove(int gameNumber, int minNumber, int maxNumber);
    }
}