using System.Numerics;

namespace SpaceBattle.Contracts
{
    /// <summary>
    /// Контракт для двигающихся объектов
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Получить текущую позицию объекта
        /// </summary>
        /// <returns>Вектор (целые числа)</returns>
        public Vector<long> GetPosition();

        /// <summary>
        /// Задать позицию объекта
        /// </summary>
        /// <param name="position">Вектор (целые числа). Новая позиция объекта</param>
        public void SetPosition(Vector<long> position);

        /// <summary>
        /// Получить текущую мгновенную скорость объекта
        /// </summary>
        /// <returns></returns>
        public Vector<long> GetVelocity();
    }
}
