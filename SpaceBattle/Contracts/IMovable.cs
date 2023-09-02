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
        ValueTuple<int, int> Position { get; set; }

        /// <summary>
        /// Вычисленная скорость объекта с учётом направления
        /// </summary>
        /// <returns></returns>
        ValueTuple<int, int> CalculatedVelocity { get; }
    }
}
