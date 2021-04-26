namespace Cube.Temperature.Converter.API.ViewModels
{
    /// <summary>
    /// Represents a single item from a dropdown (usually through dynamic forms)
    /// </summary>
    /// <typeparam name="TKey">Id type</typeparam>
    public class SelectOptionViewModel<TKey>
    {
        public SelectOptionViewModel() { }
        public SelectOptionViewModel(TKey id, string name)
        {
            Id = id;
            Name = name;
        }

        public TKey Id { get; set; }
        public string Name { get; set; }
    }
}
