using System.Numerics;

namespace SpaceBattle.Contracts
{
    /// <summary>
    /// Контракт для двигающихся объектов
    /// </summary>
    public interface IMovable : ICommand
    {
        /// <summary>
        /// Текущая позиция объекта на плоскости (x, y)
        /// </summary>
        Vector<double> Position { get; set; }

        /// <summary>
        /// Текущая мгновенная скорость объекта
        /// </summary>
        /// <returns></returns>
        Vector<double> Velocity { get; }
    }
}
