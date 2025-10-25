namespace DataGridView.Enums
{
    /// <summary>
    /// Перечисление возможных форм обучение
    /// </summary>
    public enum EducationType : byte
    {
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
