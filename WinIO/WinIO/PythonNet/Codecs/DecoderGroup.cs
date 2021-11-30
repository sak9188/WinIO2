namespace WinIO.PythonNet.Codecs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a group of <see cref="IPyObjectDecoder"/>s. Useful to group them by priority.
    /// </summary>
    [Obsolete(Util.UnstableApiMessage)]
    public sealed class DecoderGroup: IPyObjectDecoder, IEnumerable<IPyObjectDecoder>
    {
        readonly List<IPyObjectDecoder> decoders = new List<IPyObjectDecoder>();

        /// <summary>
        /// Add specified decoder to the group
        /// </summary>
        public void Add(IPyObjectDecoder item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            this.decoders.Add(item);
        }
        /// <summary>
        /// Remove all decoders from the group
        /// </summary>
        public void Clear() => this.decoders.Clear();

        /// <inheritdoc />
        public bool CanDecode(PyObject objectType, Type targetType)
            => this.decoders.Any(decoder => decoder.CanDecode(objectType, targetType));
        /// <inheritdoc />
        public bool TryDecode<T>(PyObject pyObj, out T value)
        {
            if (pyObj is null) throw new ArgumentNullException(nameof(pyObj));

            var decoder = this.GetDecoder(pyObj.GetPythonType(), typeof(T));
            if (decoder is null)
            {
                value = default;
                return false;
            }
            return decoder.TryDecode(pyObj, out value);
        }

        /// <inheritdoc />
        public IEnumerator<IPyObjectDecoder> GetEnumerator() => this.decoders.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.decoders.GetEnumerator();
    }

    [Obsolete(Util.UnstableApiMessage)]
    public static class DecoderGroupExtensions
    {
        /// <summary>
        /// Gets a concrete instance of <see cref="IPyObjectDecoder"/>
        /// (potentially selecting one from a collection),
        /// that can decode from <paramref name="objectType"/> to <paramref name="targetType"/>,
        /// or <c>null</c> if a matching decoder can not be found.
        /// </summary>
        [Obsolete(Util.UnstableApiMessage)]
        public static IPyObjectDecoder GetDecoder(
            this IPyObjectDecoder decoder,
            PyObject objectType, Type targetType)
        {
            if (decoder is null) throw new ArgumentNullException(nameof(decoder));

            if (decoder is IEnumerable<IPyObjectDecoder> composite)
            {
                return composite
                    .Select(nestedDecoder => nestedDecoder.GetDecoder(objectType, targetType))
                    .FirstOrDefault(d => d != null);
            }

            return decoder.CanDecode(objectType, targetType) ? decoder : null;
        }
    }
}
