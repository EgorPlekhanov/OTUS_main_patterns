using SpaceBattle.Contracts;

namespace SpaceBattle.GameObjects
{
    /// <summary>
    /// Космический корабль
    /// </summary>
    public class Spaceship : IGameObject
    {
        private static readonly Dictionary<string, object> properties = new();

        public object GetProperty(string name) => properties[name];

        public void SetProperty(string name, object value) => properties[name] = value;
    }
}
