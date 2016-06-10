namespace DynamicConnectivity
{
    /// <summary>
    /// A component
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Component(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; private set; }
    }
}
