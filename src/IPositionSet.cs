using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    interface IPositionSet {
        /// <summary>
        /// The type of the positions in this set
        /// </summary>
        public PositionType Type { get; }

        public void Add(Position pPos);

        public void Remove(Position pPos);

        public bool Contains(Position pPos);

        public bool CanCapture(IPositionSet pTarget);

    }
}
