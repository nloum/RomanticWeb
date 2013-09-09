using System;

namespace RomanticWeb
{
    /// <summary>
    /// Represents na Entity's identifies
    /// </summary>
    /// <remarks>Currently only URIs are supported</remarks>
    public class EntityId
    {
        private readonly Uri _uri;

        /// <summary>
        /// Creates a new instance of <see cref="EntityId"/> from string
        /// </summary>
        public EntityId(string uri)
            : this(new Uri(uri))
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="EntityId"/> from an Uniform Resource Identifies
        /// </summary>
        public EntityId(Uri uri)
        {
            _uri = uri;
        }

        /// <summary>
        /// The underlying Uniform Resource Identifier
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        public override int GetHashCode()
        {
            return (_uri != null ? _uri.GetHashCode() : 0);
        }

        /// <summary>
        /// Checks if two Entity identifiers are equal
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return _uri == ((EntityId)obj)._uri;
        }

        /// <summary>
        /// Check for equality with <param name="other"></param>
        /// </summary>
        protected bool Equals(EntityId other)
        {
            return Equals(_uri, other._uri);
        }

        /// <summary>
        /// Checks if two Entity identifiers are equal
        /// </summary>
        public static bool operator ==(EntityId left, EntityId right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Checks if two Entity identifiers are not equal
        /// </summary>
        public static bool operator !=(EntityId left, EntityId right)
        {
            return !(left == right);
        }
    }
}