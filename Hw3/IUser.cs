namespace Hw3
{
    public interface IUser
    {
        //Как зовут пользователя
        public string Name { get; set; }
        
         public int StepCount { get;  }

         public int DoMove();
    }
}