/// <summary>
/// Applcation specific extension methods for the IsolatedStorageSettings class
/// </summary>

namespace Puzzles
{
    using System.IO.IsolatedStorage;

    internal static class IsolatedStorageSettingsExtensions
    {
        private static string currentPuzzleSettingName = "CurrentPuzzleID";

        /// <summary>
        /// Gets the current puzzle ID from isolated storage
        /// </summary>
        /// <param name="appSettings">The isolated storage app settings object</param>
        /// <returns>The current puzzle ID or int.MinValue if it does not exist</returns>
        public static int GetCurrentPuzzleId(this IsolatedStorageSettings appSettings)
        {
            int result = int.MinValue;
            if(appSettings.Contains(currentPuzzleSettingName))
            {
                result = (int)appSettings[currentPuzzleSettingName];
            }

            return result;
        }

        /// <summary>
        /// Method to update the current puzzle ID in isolated storage app settings
        /// </summary>
        /// <param name="appSettings">The isolated storage app settings object</param>
        /// <param name="currentPuzzleId">The puzzle ID to update</param>
        public static void UpdateCurrentPuzzleId(this IsolatedStorageSettings appSettings, int currentPuzzleId)
        {
            appSettings[currentPuzzleSettingName] = currentPuzzleId;
            appSettings.Save();
        }
    }
}
