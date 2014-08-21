namespace Computers.Common
{
    /// <summary>
    /// Defines methods for loading values from the RAM, saving values to the RAM and drawing on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the stored value from the RAM.
        /// </summary>
        /// <returns>Returns the stored value.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves the specified value to the RAM.
        /// </summary>
        /// <param name="value">The integer value to save.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws the specified string on the video card.
        /// </summary>
        /// <param name="data">The text to draw.</param>
        void DrawOnVideoCard(string data);
    }
}
