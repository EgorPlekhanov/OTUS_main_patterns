namespace SpaceBattle.Contracts
{
    /// <summary>
    /// Контракт для вращающихся объектов
    /// </summary>
    public interface IRotatable : ICommand
    {
        /// <summary>
        /// Текущее положение
        /// </summary>
        /// <remarks>Здесь хранится значение угла. 
        /// Пример: кол-во углов = 8 (360 градусов), значит текущее значение может быть от 0 (0 градусов) до 7 (315 градусов)
        /// и повернуть объект можно на кол-во углов за 1 шаг</remarks>
        int Direction { get; set; }

        /// <summary>
        /// Кол-во углов, на сколько повернуть объект за 1 шаг
        /// </summary>
        /// <remarks>Значение может быть хоть какое (и положительное, и отрицательное, и больше-меньше кол-ва углов)</remarks>
        int DirectionsCountPerStep { get; }

        /// <summary>
        /// Кол-во углов, на которое разделена вся окружность
        /// </summary>
        int DirectionsCount { get; }
    }
}
