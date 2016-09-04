namespace Cake.Common.Tools.WiX.Insignia
{
    /// <summary>
    /// The type of input file to.
    /// </summary>
    public enum WiXInsigniaFileType
    {
        /// <summary>
        /// A value indicating a database input file.
        /// </summary>
        Database = 0,

        /// <summary>
        /// A value indicating a bundle input file.
        /// </summary>
        Bundle = 1,

        /// <summary>
        /// A value indicating to reattach burn engine.
        /// </summary>
        Reattach = 2
    }
}