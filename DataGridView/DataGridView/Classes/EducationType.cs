namespace DataGridView.Classes
{
    public enum EducationType : byte
    {
        /// <summary>
        /// Не выбрано
        /// </summary>
        None = 0,

        /// <summary>
        /// Очная
        /// </summary>
        FullTime = 1,

        /// <summary>
        /// Очно-заочная
        /// </summary>
        FullTimeAndPartTime = 2,

        /// <summary>
        /// Заочная
        /// </summary>
        PartTime = 3,
    }
}
