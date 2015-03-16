using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace GlmSharp
{
    [Serializable]
    public struct gmat2x4<T> : IReadOnlyList<T>, IEquatable<gmat2x4<T>>
    {
        // Matrix fields mXY
        public T m00, m01, m02, m03; // Column 0
        public T m10, m11, m12, m13; // Column 1
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public T[,] Values => new[,] { { m00, m01, m02, m03 }, { m10, m11, m12, m13 } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public T[] Values1D => new[] { m00, m01, m02, m03, m10, m11, m12, m13 };
        
        /// <summary>
        /// Returns the column nr 0
        /// </summary>
        public gvec4<T> Column0 => new gvec4<T>(m00, m01, m02, m03);
        
        /// <summary>
        /// Returns the column nr 1
        /// </summary>
        public gvec4<T> Column1 => new gvec4<T>(m10, m11, m12, m13);
        
        /// <summary>
        /// Returns the row nr 0
        /// </summary>
        public gvec2<T> Row0 => new gvec2<T>(m00, m10);
        
        /// <summary>
        /// Returns the row nr 1
        /// </summary>
        public gvec2<T> Row1 => new gvec2<T>(m01, m11);
        
        /// <summary>
        /// Returns the row nr 2
        /// </summary>
        public gvec2<T> Row2 => new gvec2<T>(m02, m12);
        
        /// <summary>
        /// Returns the row nr 3
        /// </summary>
        public gvec2<T> Row3 => new gvec2<T>(m03, m13);
        
        /// <summary>
        /// Predefined all-zero matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly gmat2x4<T> Zero = new gmat2x4<T>(default(T), default(T), default(T), default(T), default(T), default(T), default(T), default(T));
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public gmat2x4(T m00, T m01, T m02, T m03, T m10, T m11, T m12, T m13)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m03 = m03;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
        }
        
        /// <summary>
        /// Copy constructor
        /// </summary>
        public gmat2x4(gmat2x4<T> m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = m.m03;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = m.m13;
        }
        
        /// <summary>
        /// Column constructor
        /// </summary>
        public gmat2x4(gvec4<T> c0, gvec4<T> c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m03 = c0.w;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m13 = c1.w;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            yield return m00;
            yield return m01;
            yield return m02;
            yield return m03;
            yield return m10;
            yield return m11;
            yield return m12;
            yield return m13;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns the number of components (8).
        /// </summary>
        public int Count => 8;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public T this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m03;
                    case 4: return m10;
                    case 5: return m11;
                    case 6: return m12;
                    case 7: return m13;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m02 = value; break;
                    case 3: this.m03 = value; break;
                    case 4: this.m10 = value; break;
                    case 5: this.m11 = value; break;
                    case 6: this.m12 = value; break;
                    case 7: this.m13 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public T this[int col, int row]
        {
            get
            {
                return this[col * 4 + row];
            }
            set
            {
                this[col * 4 + row] = value;
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(gmat2x4<T> rhs) => EqualityComparer<T>.Default.Equals(m00, rhs.m00) && EqualityComparer<T>.Default.Equals(m01, rhs.m01) && EqualityComparer<T>.Default.Equals(m02, rhs.m02) && EqualityComparer<T>.Default.Equals(m03, rhs.m03) && EqualityComparer<T>.Default.Equals(m10, rhs.m10) && EqualityComparer<T>.Default.Equals(m11, rhs.m11) && EqualityComparer<T>.Default.Equals(m12, rhs.m12) && EqualityComparer<T>.Default.Equals(m13, rhs.m13);
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is gmat2x4<T> && Equals((gmat2x4<T>) obj);
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(gmat2x4<T> lhs, gmat2x4<T> rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(gmat2x4<T> lhs, gmat2x4<T> rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((EqualityComparer<T>.Default.GetHashCode(m00)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m01)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m02)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m03)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m10)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m11)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m12)) * 397) ^ EqualityComparer<T>.Default.GetHashCode(m13);
            }
        }
    }
}