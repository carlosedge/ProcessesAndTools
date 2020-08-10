using DbToFile.Contract.Interfaces;
namespace DbToFileTool.BusinessLogic
{
    /// <summary>
    /// Provides creation methods for <see cref="IFileWriter" interface./>
    /// </summary>
    internal interface IFileWriterFactory
    {
        /// <summary>
        /// Creates a <see cref="IFileWriter"/> by specifying the file type to generate.
        /// </summary>
        /// <param name="fileType">fileType in string format</param>
        /// <returns></returns>
        IFileWriter Create(string fileType);
    }
}
