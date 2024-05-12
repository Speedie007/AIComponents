namespace AIComponents.Data.Domain
{
    public partial interface IBaseEntity
    {
        int Id { get; set; }
    }
    /// <summary>
    /// Represents the base class for entities
    /// </summary>
    public abstract partial class NodeBaseContextEntity : IBaseEntity
    {
        public NodeBaseContextEntity()
        {
            Id = 0;
        }
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
    }
}
