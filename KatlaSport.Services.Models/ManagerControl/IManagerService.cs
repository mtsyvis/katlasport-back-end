using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ManagerControl
{
    using System.IO;

    /// <summary>
    /// Represents a manager service.
    /// </summary>
    public interface IManagerService
    {
        /// <summary>
        /// Gets the managers asynchronous.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>A <see cref="Task{List{Manager}}"/></returns>
        Task<List<Manager>> GetManagersAsync(int start, int amount);

        /// <summary>
        /// Gets the manager asynchronous.
        /// </summary>
        /// <param name="managerId">The manager identifier.</param>
        /// <returns>A <see cref="Task{Manager}"/></returns>
        Task<Manager> GetManagerAsync(int managerId);

        /// <summary>
        /// Creates the manager asynchronous.
        /// </summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>A <see cref="Task{Manager}"/></returns>
        Task<Manager> CreateManagerAsync(UpdateManagerRequest createRequest);

        /// <summary>
        /// Updates the manager asynchronous.
        /// </summary>
        /// <param name="managerId">The manager identifier.</param>
        /// <param name="updateRequest">The update request.</param>
        /// <returns>A <see cref="Task{Manager}"</returns>
        Task<Manager> UpdateManagerAsync(int managerId, UpdateManagerRequest updateRequest);

        /// <summary>
        /// Deletes the manager asynchronous.
        /// </summary>
        /// <param name="managerId">The customer identifier.</param>
        /// <returns>A <see cref="Task"/></returns>
        Task DeleteManagerAsync(int managerId);

        /// <summary>
        /// Sets the status asynchronous.
        /// </summary>
        /// <param name="managerId">The manager identifier.</param>
        /// <param name="deletedStatus">if set to <c>true</c> [deleted status].</param>
        /// <returns>A <see cref="Task"/></returns>
        Task SetStatusAsync(int managerId, bool deletedStatus);

        /// <summary>
        /// Uploads the file image.
        /// </summary>
        /// <param name="managerId">The manager identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileStream">The file stream.</param>
        /// <returns>A <see cref="Task"/></returns>
        Task<bool> UploadFileImage(int managerId, string fileName, Stream fileStream);

        /// <summary>
        /// Gets the subordinates.
        /// </summary>
        /// <param name="managerId">The manager identifier.</param>
        /// <returns>A <see cref="Task{List{Manager}}"</returns>
        Task<List<Manager>> GetSubordinates(int managerId);
    }
}
