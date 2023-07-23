using System;
using System.Collections;

namespace System.Data.NMQTT
{
    public sealed class SessionDeletedEventArgs : EventArgs
    {
        public SessionDeletedEventArgs(string id, IDictionary sessionItems)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the ID of the session.
        /// </summary>
        public string Id { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
}