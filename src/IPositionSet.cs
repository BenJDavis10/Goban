using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {

    /// <summary>
    /// Represents a set of positions with shared properties
    /// </summary>
    interface IPositionSet {
        /// <summary>
        /// The type of the positions in this set
        /// </summary>
        public PositionType Type { get; }


        /// <summary>
        /// Adds the given position to this position set
        /// </summary>
        /// <param name="pPos">The position to add</param>
        public void Add(Position pPos);


        /// <summary>
        /// Adds the given set of positions to this position set
        /// </summary>
        /// <param name="pPositions">The set of positions to add</param>
        public void AddAll(ISet<Position> pPositions);


        /// <summary>
        /// Removes the given position from this position set
        /// </summary>
        /// <param name="pPos">The position to remove</param>
        public void Remove(Position pPos);


        /// <summary>
        /// Determines whether this position set contains the given position
        /// </summary>
        /// <param name="pPos">The position to check</param>
        /// <returns>true if pPos is in this set, false otherwise</returns>
        public bool Contains(Position pPos);


        /// <summary>
        /// Determines whether this position set can capture the given target
        /// </summary>
        /// <param name="pTarget">The target position set</param>
        /// <returns>true if pTarget can be captured by this set, false otherwise</returns>
        public bool CanCapture(IPositionSet pTarget);

    }
}
