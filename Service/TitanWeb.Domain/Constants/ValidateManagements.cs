namespace TitanWeb.Domain.Constants
{
    /// <summary>
    /// Class Manage All Hard-Code Validate
    /// </summary>
    public static class ValidateManagements
    {
        /// <summary>
        /// Validate Image Display Name
        /// </summary>
        public const string ImageName = "Image Name";
        public const string ImageFile = "Image File";
        public const string IsLogo = "Is Logo";

        /// <summary>
        /// Validate Page Display Name
        /// </summary>
        public const string PageSize = "Page Size";
        public const string PageNumber = "Page Number";

        /// <summary>
        /// Validate Locale Display Name
        /// </summary>
        public const string Locale = "Locale";

        /// <summary>
        /// Validate Request From Display Name
        /// </summary>
        public const string RequestFormName = "Request Form Name";
        public const string RequestFormEmail = "Request Form Email";
        public const string RequestFormPhone = "Request Form Phone";
        public const string RequestFormSubject = "Request Form Subject";
        public const string RequestFormMessage = "Request Form Message";

        /// <summary>
        /// Validate Keyword Display Name
        /// </summary>
        public const string Keyword = "Keyword";

        /// <summary>
        /// Validate News Display Name
        /// </summary>
        public const string NewsId = "News Id";
        public const string NewsTitle = "News Title";
        public const string NewsSlug = "News Slug";
        public const string NewsShortDescription = "News Short Description";
        public const string NewsDescription = "News Description";
        public const string NewsImage = "News Image";

        /// <summary>
        /// Validate Blog Display Name
        /// </summary>
        public const string BlogId = "Blog Id";
        public const string BlogTitle = "Blog Title";
        public const string BlogSubTitle = "Blog Sub-Title";
        public const string BlogSlug = "Blog Slug";
        public const string BlogShortDescription = "Blog Short Description";
        public const string BlogDescription = "Blog Description";
        public const string BlogImage = "Blog Image";

        /// <summary>
        /// Validate Section Display Name
        /// </summary>
        public const string SectionId = "Section Id";
        public const string SectionName = "Section Name";
        public const string SectionTitle = "Section Title";
        public const string SectionSlug = "Section Slug";
        public const string SectionDescription = "Section Description";
        public const string SectionBackgroundImage = "Section Background Image";

        /// <summary>
        /// Validate Banner Display Name
        /// </summary>
        public const string BannerId = "Banner Id";
        public const string BannerBoldTitle = "Banner Bold Title";
        public const string BannerTitle = "Banner Title";
        public const string BannerSlug = "Banner Slug";
        public const string BannerDescription = "Banner Description";
        public const string BannerBackgroundImage = "Banner Background Image";

        /// <summary>
        /// Validate Category Display Name
        /// </summary>
        public const string CategorySlug = "Category Slug";

        /// <summary>
        /// Validate Section Item Display Name
        /// </summary>
        public const string SectionItemId = "Section Item Id";
        public const string SectionItemTitle = "Section Item Title";
        public const string SectionItemSubTitle = "Section Item Sub Title";
        public const string SectionItemSlug = "Section Item Slug";
        public const string SectionItemDescription = "Section Item Description";
        public const string SectionItemImage = "Section Item Image";

        /// <summary>
        /// Validate Button Display Name
        /// </summary>
        public const string ButtonLabel = "Button Label";

        /// <summary>
        /// Validate Sub-Item Display Name
        /// </summary>
        public const string SubItemId = "Sub-Item Id";
        public const string SubItemText = "Sub-Item Text";
        public const string SubItemImage = "Sub-Item Image";
        public const string ItemSlug = "Item Slug";

        /// <summary>
        /// Validate Length
        /// </summary>
        public const int MaxLength20 = 20;
        public const int MaxLength50 = 50;
        public const int MaxLength100 = 100;
        public const int MaxLength500 = 500;

        /// <summary>
        /// Reponse Image Error When Validate
        /// </summary>
        public const string LocaleRequiredMsg = "Locale cannot be empty!!";

        /// <summary>
        /// Reponse Image Error When Validate
        /// </summary>
        public const string NameRequiredMsg = "Name cannot be empty!!";
        public const string NameMaxLengthMsg = "Name length only 100!!";
        public const string FileRequiredMsg = "File cannot be empty!!";
        public const string HyperlinkMaxLengthMsg = "Hyperlink length only 100!!";
        public const string IsLogoRequiredMsg = "Is Logo cannot be empty!!";

        /// <summary>
        /// Reponse Page Error When Validate
        /// </summary>
        public const string PageSizeEmptyMsg = "Page Size cannot be empty!!";
        public const string PageNumberEmptyMsg = "Page Number cannot be empty!!";

        /// <summary>
        /// Reponse Request Form Error When Validate
        /// </summary>
        public const string RequestFormNameRequiredMsg = "Request Form Name cannot be empty!!";
        public const string RequestFormNameMaxLengthMsg = "Request Form Name length only 50!!";
        public const string RequestFormEmailRequiredMsg = "Request Form Email cannot be empty!!";
        public const string RequestFormEmailMaxLengthMsg = "Request Form Email length only 50!!";
        public const string RequestFormEmailValidateErrorMsg = "Invalid Email Address";
        public const string RequestFormPhoneMaxLengthMsg = "Request Form Phone length only 20!!";
        public const string RequestFormSubjectRequiredMsg = "Request Form Subject cannot be empty!!";
        public const string RequestFormSubjectMaxLengthMsg = "Request Form Subject length only 50!!";
        public const string RequestFormMessageRequiredMsg = "Request Form Message cannot be empty!!";
        public const string RequestFormMessageMaxLengthMsg = "Request Form Message length only 500!!";

        /// <summary>
        /// Reponse News Error When Validate
        /// </summary>
        public const string NewsTitleRequiredMsg = "News Title cannot be empty!!";
        public const string NewsTitleMaxLength = "News Title length only 100";
        public const string NewsSlugRequiredMsg = "News Slug cannot be empty!!";
        public const string NewsSlugMaxLength = "News Slug length only 100";
        public const string NewsShortDescriptionRequiredMsg = "News Short Description cannot be empty!!";
        public const string NewsShortDescriptionMaxLength = "News Short Description length only 500";
        public const string NewsDescriptionRequiredMsg = "News Description cannot be empty!!";
        public const string NewsDescriptionMaxLength = "News Description length only 500";

        /// <summary>
        /// Reponse Blog Error When Validate
        /// </summary>
        public const string BlogTitleRequiredMsg = "Blog Title cannot be empty!!";
        public const string BlogTitleMaxLength = "Blog Title length only 100";
        public const string BlogSubTitleRequiredMsg = "Blog Sub-Title cannot be empty!!";
        public const string BlogSubTitleMaxLength = "Blog Sub-Title length only 100";
        public const string BlogSlugRequiredMsg = "Blog Slug cannot be empty!!";
        public const string BlogSlugMaxLength = "Blog Slug length only 100";
        public const string BlogShortDescriptionRequiredMsg = "Blog Short Description cannot be empty!!";
        public const string BlogShortDescriptionMaxLength = "Blog Short Description length only 500";
        public const string BlogDescriptionRequiredMsg = "Blog Description cannot be empty!!";
        public const string BlogDescriptionMaxLength = "Blog Description length only 500";

        /// <summary>
        /// Reponse Section Error When Validate
        /// </summary>
        public const string SectionNameRequiredMsg = "Section Name cannot be empty!!";
        public const string SectionNameMaxLength = "Section Name length only 100";
        public const string SectionTitleRequiredMsg = "Section Title cannot be empty!!";
        public const string SectionTitleMaxLength = "Section Title length only 100";
        public const string SectionSlugRequiredMsg = "Section Slug cannot be empty!!";
        public const string SectionSlugMaxLength = "Section Slug length only 100";
        public const string SectionDescriptionMaxLength = "Section Description length only 500";

        /// <summary>
        /// Reponse Banner Error When Validate
        /// </summary>
        public const string BannerTitleRequiredMsg = "Banner Title cannot be empty!!";
        public const string BannerTitleMaxLength = "Banner Title length only 100";
        public const string BannerSlugRequiredMsg = "Banner Slug cannot be empty!!";
        public const string BannerSlugMaxLength = "Banner Slug length only 100";
        public const string BannerDescriptionRequiredMsg = "Banner Description cannot be empty!!";
        public const string BannerDescriptionMaxLength = "Banner Description length only 500";

        /// <summary>
        /// Reponse Category Error When Validate
        /// </summary>
        public const string CategorySlugRequiredMsg = "Category Slug cannot be empty!!";
        public const string CategorySlugMaxLength = "Category Slug length only 100";

        /// <summary>
        /// Reponse Button Error When Validate
        /// </summary>
        public const string ButtonLabelRequiredMsg = "Button Label cannot be empty!!";
        public const string ButtonLabelMaxLength = "Button Label length only 100";

        /// <summary>
        /// Reponse Section Item Error When Validate
        /// </summary>
        public const string SectionItemTitleRequiredMsg = "Section Title cannot be empty!!";
        public const string SectionItemTitleMaxLength = "Section Title length only 100";
        public const string SectionItemSubTitleRequiredMsg = "Section Title cannot be empty!!";
        public const string SectionItemSubTitleMaxLength = "Section Title length only 100";
        public const string SectionItemSlugRequiredMsg = "Section Item Slug cannot be empty!!";
        public const string SectionItemSlugMaxLength = "Section Item Slug length only 100";
        public const string SectionItemDescriptionRequiredMsg = "Section Description cannot be empty!!";
        public const string SectionItemDescriptionMaxLength = "Section Description length only 500";

        /// <summary>
        /// Reponse Sub-Item Error When Validate
        /// </summary>
        public const string SubItemTextRequiredMsg = "Sub-Item Text cannot be empty!!";
        public const string SubItemTextMaxLength = "Sub-Item Text length only 100";
        public const string ItemSlugRequiredMsg = "Section Item Slug cannot be empty!!";
        public const string ItemSlugMaxLength = "Section Item Slug length only 100";
    }
}
