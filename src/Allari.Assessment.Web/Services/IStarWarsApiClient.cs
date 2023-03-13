using Allari.Assessment.Web.Models;

namespace Allari.Assessment.Web.Services
{
    public interface IStarWarsApiClient
    {
        /// <summary>
        /// Get people info from Star Wars Universe API SYNCHRONOUSLY.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<StarWarsPeople> GetPeople(string path);

        /// <summary>
        /// Get people from Star Wars API ASYNCHRONOUSLY.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<List<StarWarsPeople>> GetPeopleAsync(string path);
    }
}
