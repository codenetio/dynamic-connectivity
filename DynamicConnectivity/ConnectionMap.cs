using System.Collections.Generic;
using System.Linq;

namespace DynamicConnectivity
{
    /// <summary>
    /// Represents the connections among components
    /// </summary>
    public class ConnectionMap
    {
        private readonly List<List<Component>> _componentSets;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionMap"/> class.
        /// </summary>
        public ConnectionMap()
        {
            _componentSets = new List<List<Component>>();
        }

        /// <summary>
        /// Connects the specified components if they are not connected.
        /// </summary>
        /// <param name="componentA">The component a.</param>
        /// <param name="componentB">The component b.</param>
        public void Union(Component componentA, Component componentB)
        {
            // return if they're already connected
            if (Connected(componentA, componentB)) return;

            // find the component sets that each component is in
            var componentASet = _componentSets.FirstOrDefault(s => s.Contains(componentA));
            var componentBSet = _componentSets.FirstOrDefault(s => s.Contains(componentB));

            // check to see if the components are actually in existing component sets or not
            if (componentASet == null && componentBSet == null)
            {
                // neither are in a component set.
                _componentSets.Add(new List<Component> {componentA, componentB});
            }
            else if (componentASet != null && componentBSet == null)
            {
                // a is in a component set, but b is not
                componentASet.Add(componentB);
            }
            else if (componentASet == null && componentBSet != null)
            {
                // b is in a component set, but a is not
                componentBSet.Add(componentA);
            }
            else
            {
                // both are in separate component sets so we merge them using the Union method on the list object.
                // then we remove the individual sets from the collection and add the new merged set.
                var newSet = componentASet.Union(componentBSet).ToList();
                _componentSets.Remove(componentASet);
                _componentSets.Remove(componentBSet);
                _componentSets.Add(newSet);
            }
        }

        /// <summary>
        /// Determines whether thespecified components are connected.
        /// </summary>
        /// <param name="componentA">Component A.</param>
        /// <param name="componentB">Component B.</param>
        /// <returns>True if connected; otherwise false.</returns>
        public bool Connected(Component componentA, Component componentB)
        {
            return _componentSets.FirstOrDefault(s => s.Contains(componentA))?.Contains(componentB) ?? false;
        }
    }
}
