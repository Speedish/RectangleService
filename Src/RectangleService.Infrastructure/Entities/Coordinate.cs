using System.ComponentModel.DataAnnotations;

namespace RectangleService.Infrastructure.Entities
{
    /// <summary>
    /// Coordinate
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        [Required]
        public int X { get; set; }
        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        [Required]
        public int Y { get; set; }
    }
}
