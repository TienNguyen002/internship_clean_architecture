namespace TitanWeb.Domain.Constants
{
    /// <summary>
    /// Class Manage All Hard-Code Log 
    /// </summary>
    public static class LogManagements
    {
        /// <summary>
        /// Log Validate Input
        /// </summary>
        public static readonly string ValidateInput = "\nValidate Input";

        /// <summary>
        /// Log Exception
        /// </summary>
        public static readonly string ExceptionMSG = "\nException: ";
        public static readonly string InnerExceptionMSG = "\nInner Exception: ";
        public static readonly string ErrorMSG = "\nError: ";

        /// <summary>
        /// Log Func Image
        /// </summary>
        public static readonly string LogGetAllImages = "\nGetting All Images";
        public static readonly string LogGetAllLogoImages = "\nGetting All Logo Images";
        public static readonly string LogGetImageById = "\nGetting Image By Id ";
        public static readonly string LogReturnImage = "\nReturn Images Result";
        public static readonly string LogReturnLogoImage = "\nReturn Logo Images Result";
        public static readonly string LogReturnImageById = "\nReturn Image By Id ";
        public static readonly string LogCreateImage = "\nCreating Image";
        public static readonly string LogDeleteImage = "\nDelete Image By Id ";

        /// <summary>
        /// Log Func Item
        /// </summary>
        public static readonly string LogGetItemByQuery = "\nGetting Item By Query";
        public static readonly string LogGetItemById = "\nGetting Item By Id ";
        public static readonly string LogGetItemBySlug = "\nGetting Item By Slug ";
        public static readonly string LogGetItemByCategorySlug = "\nGetting Item By Category Slug ";
        public static readonly string LogReturnItemByQuery = "\nReturn Items Result";
        public static readonly string LogReturnItemById = "\nReturn Item By Id ";
        public static readonly string LogReturnItemBySlug = "\nReturn Item By Slug ";
        public static readonly string LogReturnItemByCategorySlug = "\nReturn Item By Category Slug ";
        public static readonly string LogCreateItem = "\nCreating Item";
        public static readonly string LogUpdateImageForItem = "\nUpdating Image For Item With Id ";
        public static readonly string LogDeleteItem = "\nDelete Item By Id ";

        /// <summary>
        /// Log Func Section
        /// </summary>
        public static readonly string LogGetAllSections = "\nGetting All Sections";
        public static readonly string LogGetAllSectionsBySlug = "\nGetting All Sections By Slug ";
        public static readonly string LogGetSectionBySlug = "\nGetting Section By Slug ";
        public static readonly string LogReturnSection= "\nReturn Sections Result";
        public static readonly string LogReturnSectionBySlug = "\nReturn Section By Slug ";
        public static readonly string LogReturnAllSectionsBySlug = "\nReturn All Sections By Slug ";
        public static readonly string LogCreateSection = "\nCreating Section";
        public static readonly string LogDeleteSection = "\nDelete Section By Id ";

        /// <summary>
        /// Log Func Request Form
        /// </summary>
        public static readonly string LogGetRequestFormByQuery = "\nGetting Request Forms By Query";
        public static readonly string LogReturnRequestFormByQuery = "\nReturn Request Forms Result";
        public static readonly string LogCreateRequestForm = "\nCreating Request Form";
        public static readonly string LogDeleteRequestForm = "\nDelete Request Form By Id ";

        /// <summary>
        /// Log Func Category
        /// </summary>
        public static readonly string LogGetAllCategories = "\nGetting All Categories";
        public static readonly string LogGetCategoryBySlug = "\nGetting Category By Slug ";
        public static readonly string LogReturnCategory = "\nReturn Categories Result";
        public static readonly string LogReturnCategoryBySlug = "\nReturn Category By Slug ";
        public static readonly string LogCreateCategory = "\nCreating Category";
        public static readonly string LogDeleteCategory = "\nDelete Category By Id ";

        /// <summary>
        /// Log Func Logo
        /// </summary>
        public static readonly string LogChangeLogo = "\nChanging Logo";

        /// <summary>
        /// Log Func News, Bloh
        /// </summary>
        public static readonly string LogEditNews = "\nEditting News";
        public static readonly string LogEditBlog = "\nEditting Blog";
    }
}
