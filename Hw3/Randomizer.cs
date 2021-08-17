using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Http.Headers;

namespace Hw3
{
    public static class Randomizer
    {
        private static readonly Random RandomObjectInitialized = new Random((int) DateTime.Now.Ticks & 0x0000FFFF); 
     
        /// <summary>
        /// Возвращает случайное число, которое включает минимальное и максимальное значение
        /// Объект инициализируется по таймеру, что позволяет постоянно получать новые числа
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <returns>Целое случайное число</returns>
        public static int GetRandom(int minValue, int maxValue)=>RandomObjectInitialized.Next(minValue - 1, maxValue) + 1;
        
    }
}