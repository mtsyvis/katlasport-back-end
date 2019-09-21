using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive service.
    /// </summary>
    public interface IHiveService
    {
        /// <summary>
        /// Gets a hives list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Hive}}"/>.</returns>
        Task<List<HiveListItem>> GetHivesAsynk();

        /// <summary>
        /// Gets a hive with specified identifier.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<Hive> GetHiveAsynk(int hiveId);

        /// <summary>
        /// Creates a new hive.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateHiveRequest"/>.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<Hive> CreateHiveAsynk(UpdateHiveRequest createRequest);

        /// <summary>
        /// Updates an existed hive.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateHiveRequest"/>.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<Hive> UpdateHiveAsynk(int hiveId, UpdateHiveRequest updateRequest);

        /// <summary>
        /// Deletes an existed hive.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param
        /// <returns>A <see cref="Task"/></returns>
        Task DeleteHiveAsynk(int hiveId);

        /// <summary>
        /// Sets the status asynk.
        /// </summary>
        /// <param name="hiveId">The hive identifier.</param>
        /// <param name="deletedStatus">if set to <c>true</c> [deleted status].</param>
        /// <returns>A <see cref="Task"/></returns>
        Task SetStatusAsynk(int hiveId, bool deletedStatus);
    }
}
