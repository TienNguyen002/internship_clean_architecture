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
        public const string NewsJapaneseTitle = "News Japanese Title";
        public const string NewsShortDescription = "News Short Description";
        public const string NewsJapaneseShortDescription = "News Japanese Short Description";
        public const string NewsDescription = "News Description";
        public const string NewsJapaneseDescription = "News Japanese Description";
        public const string NewsImage = "News Image";

        /// <summary>
        /// Validate Blog Display Name
        /// </summary>
        public const string BlogId = "Blog Id";
        public const string BlogTitle = "Blog Title";
        public const string BlogJapaneseTitle = "Blog Japanese Title";
        public const string BlogSubTitle = "Blog Sub-Title";
        public const string BlogShortDescription = "Blog Short Description";
        public const string BlogJapaneseShortDescription = "Blog Japanese Short Description";
        public const string BlogDescription = "Blog Description";
        public const string BlogJapaneseDescription = "Blog Japanese Description";
        public const string BlogImage = "Blog Image";

        /// <summary>
        /// Validate Section Display Name
        /// </summary>
        public const string SectionId = "Section Id";
        public const string SectionName = "Section Name";
        public const string SectionTitle = "Section Title";
        public const string SectionSlug = "Section Slug";
        public const string SectionJapaneseTitle = "Section Japanese Title";
        public const string SectionDescription = "Section Description";
        public const string SectionJapaneseDescription = "Section Japanese Description";
        public const string SectionBackgroundImage = "Section Background Image";

        /// <summary>
        /// Validate Banner Display Name
        /// </summary>
        public const string BannerId = "Banner Id";
        public const string BannerBoldTitle = "Banner Bold Title";
        public const string BannerJapaneseBoldTitle = "Banner Japanese Bold Title";
        public const string BannerTitle = "Banner Title";
        public const string BannerJapaneseTitle = "Banner Japanese Title";
        public const string BannerDescription = "Banner Description";
        public const string BannerJapaneseDescription = "Banner Japanese Description";
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
        /// Validate Item Display Name
        /// </summary>
        public const string ItemId = "Item Id";
        public const string ItemTitle = "Item Title";
        public const string ItemJapaneseTitle = "Item Japanese Title";
        public const string ItemSubTitle = "Item Customer Position ";
        public const string ItemJapaneseSubTitle = "Item Japanese Customer Position ";
        public const string ItemDescription = "Item Description";
        public const string ItemJapaneseDescription = "Item Japanese Description";
        public const string ItemButtonLabel = "Item Button Label";
        public const string ItemJapaneseButtonLabel = "Item Japanese Button Label";
        public const string ItemImage = "Item Image";

        /// <summary>
        /// Validate Sub-Item Display Name
        /// </summary>
        public const string SubItemId = "Sub-Item Id";
        public const string SubItemText = "Sub-Item Text";
        public const string SubItemImage = "Sub-Item Image";
        public const string SubItemSlug = "Item Slug";

        /// <summary>
        /// Validate Footer Item Display Name
        /// </summary>
        public const string FooterItemId = "Footer Item Id";
        public const string FooterItemTitle = "Footer Item Title";
        public const string FooterItemJapaneseTitle = "Footer Item Japanese Title";
        public const string FooterItemAddress = "Footer Item Address";
        public const string FooterItemTelNumber = "Footer Item TelNumber";
        public const string FooterItemDescription = "Footer Item Description";
        public const string FooterItemJapaneseDescription = "Footer Item Japanese Description";
        public const string FooterItem1stGmail = "Footer Item InfoGmail1";
        public const string FooterItem2ndGmail = "Footer Item InfoGmail2";
        public const string FooterItemSkype = "Footer Item Skype";
        public const string FooterItemFacebook = "Footer Item Facebook";
        public const string FooterItemTwitter = "Footer Item Twitter";
        public const string FooterItemLinkedin = "Footer Item Linkedin";
        public const string FooterItemYoutube = "Footer Item Youtube";

        /// <summary>
        /// Validate Length
        /// </summary>
        public const int MaxLength20 = 20;
        public const int MaxLength50 = 50;
        public const int MaxLength100 = 100;
        public const int MaxLength200 = 200;
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
        public const string NewsJapaneseTitleRequiredMsg = "News Japanese Title cannot be empty!!";
        public const string NewsJapaneseTitleMaxLength = "News Japanese Title length only 100";
        public const string NewsSlugRequiredMsg = "News Slug cannot be empty!!";
        public const string NewsSlugMaxLength = "News Slug length only 100";
        public const string NewsShortDescriptionRequiredMsg = "News Short Description cannot be empty!!";
        public const string NewsShortDescriptionMaxLength = "News Short Description length only 500";
        public const string NewsJapaneseShortDescriptionRequiredMsg = "News Japanese Short Description cannot be empty!!";
        public const string NewsJapaneseShortDescriptionMaxLength = "News Japanese Short Description length only 500";
        public const string NewsDescriptionRequiredMsg = "News Description cannot be empty!!";
        public const string NewsDescriptionMaxLength = "News Description length only 500";
        public const string NewsJapaneseDescriptionRequiredMsg = "News Japanese Description cannot be empty!!";
        public const string NewsJapaneseDescriptionMaxLength = "News Japanese Description length only 500";

        /// <summary>
        /// Reponse Blog Error When Validate
        /// </summary>
        public const string BlogTitleRequiredMsg = "Blog Title cannot be empty!!";
        public const string BlogTitleMaxLength = "Blog Title length only 100";
        public const string BlogJapaneseTitleRequiredMsg = "Blog Japanese Title cannot be empty!!";
        public const string BlogJapaneseTitleMaxLength = "Blog Japanese Title length only 100";
        public const string BlogSubTitleRequiredMsg = "Blog Sub-Title cannot be empty!!";
        public const string BlogSubTitleMaxLength = "Blog Sub-Title length only 100";
        public const string BlogSlugRequiredMsg = "Blog Slug cannot be empty!!";
        public const string BlogSlugMaxLength = "Blog Slug length only 100";
        public const string BlogShortDescriptionRequiredMsg = "Blog Short Description cannot be empty!!";
        public const string BlogShortDescriptionMaxLength = "Blog Short Description length only 500";
        public const string BlogJapaneseShortDescriptionRequiredMsg = "Blog Japanese Short Description cannot be empty!!";
        public const string BlogJapaneseShortDescriptionMaxLength = "Blog Japanese Short Description length only 500";
        public const string BlogDescriptionRequiredMsg = "Blog Description cannot be empty!!";
        public const string BlogDescriptionMaxLength = "Blog Description length only 500";
        public const string BlogJapaneseDescriptionRequiredMsg = "Blog Japanese Description cannot be empty!!";
        public const string BlogJapaneseDescriptionMaxLength = "Blog Japanese Description length only 500";

        /// <summary>
        /// Reponse Section Error When Validate
        /// </summary>
        public const string SectionNameRequiredMsg = "Section Name cannot be empty!!";
        public const string SectionNameMaxLength = "Section Name length only 100";
        public const string SectionTitleRequiredMsg = "Section Title cannot be empty!!";
        public const string SectionTitleMaxLength = "Section Title length only 100";
        public const string SectionJapaneseTitleRequiredMsg = "Section Japanese Title cannot be empty!!";
        public const string SectionJapaneseTitleMaxLength = "Section Japanese Title length only 100";
        public const string SectionSlugRequiredMsg = "Section Slug cannot be empty!!";
        public const string SectionSlugMaxLength = "Section Slug length only 100";
        public const string SectionDescriptionMaxLength = "Section Description length only 500";
        public const string SectionJapaneseDescriptionMaxLength = "Section Japanese Description length only 500";

        /// <summary>
        /// Reponse Banner Error When Validate
        /// </summary>
        public const string BannerTitleRequiredMsg = "Banner Title cannot be empty!!";
        public const string BannerTitleMaxLength = "Banner Title length only 100";
        public const string BannerJapaneseTitleRequiredMsg = "Banner Japanese Title cannot be empty!!";
        public const string BannerJapaneseTitleMaxLength = "Banner Japanese Title length only 100";
        public const string BannerSlugRequiredMsg = "Banner Slug cannot be empty!!";
        public const string BannerSlugMaxLength = "Banner Slug length only 100";
        public const string BannerDescriptionRequiredMsg = "Banner Description cannot be empty!!";
        public const string BannerDescriptionMaxLength = "Banner Description length only 500";
        public const string BannerJapaneseDescriptionRequiredMsg = "Banner Japanese Description cannot be empty!!";
        public const string BannerJapaneseDescriptionMaxLength = "Banner Japanese Description length only 500";

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
        public const string SubItemSlugRequiredMsg = "Sub-Item Slug cannot be empty!!";
        public const string SubItemSlugMaxLength = "Sub-Item Slug length only 100";

        /// <summary>
        /// Reponse Footer Item Error When Validate
        /// </summary>
        public const string FooterItemTitleRequiredMsg = "Footer Item Title cannot be empty!!";
        public const string FooterItemTitleMaxLength = "Footer Item Title length only 100";
        public const string FooterItemJapaneseTitleRequiredMsg = "Footer Item Japanese Title cannot be empty!!";
        public const string FooterItemJapaneseTitleMaxLength = "Footer Item Japanese Title length only 100";
        public const string FooterItemSlugRequiredMsg = "Footer Item Slug cannot be empty!!";
        public const string FooterItemSlugMaxLength = "Footer Item Slug length only 100";
        public const string FooterItemAddressMaxLength = "Footer Item Address length only 200";
        public const string FooterItemTelNumberMaxLength = "Footer Item Tel Number length only 20";
        public const string FooterItemInfoGmailMaxLength = "Footer Item Info Gmail length only 50";
        public const string FooterItemInfoGmail2MaxLength = "Footer Item Info Gmail2 length only 50";

        //Swagger Docs
        public const string SwaggerDocDesc = "An API to manage contents on Titan Corp Website";
        public const string SwaggerDocTOS = "https://example.com/terms";
        public const string SwaggerDocContactName = "Nguyễn Hoàng Nhật Tiến - Nguyễn Quang Hưng - Lê Tân";
        public const string SwaggerDocContactEmail = "2011391@dlu.edu.vn";

        //Item Edit Model Constants
        public const string ItemTitleRequiredMsg = "Item Title cannot be empty!";
        public const string ItemTitleMaxLength = "Item Title length must not be 100 characters";
        public const string ItemJapaneseTitleRequiredMsg = "Item Japanese Title cannot be empty!";
        public const string ItemJapaneseTitleMaxLength = "Item Japanese Title length must not be 100 characters";
        public const string ItemSubTitleMaxLength = "Customer Position must not contain more than 100 characters!";
        public const string ItemJapaneseSubTitleMaxLength = "Japanese Customer Position must not contain more than 100 characters!";
        public const string ItemDescriptionMaxLength = "Item Description length only 500";
        public const string ItemJapaneseDescriptionMaxLength = "Item Japanese Description length only 500";
        public const string ItemButtonLabelMaxLength = "Item Button Label length only 100";
        public const string ItemJapaneseButtonLabelMaxLength = "Item Japanese Button Label length only 100";

        //All purpose
        public const string TitleRequiredMsg = "Title cannot be empty!";
        public const string ItemRequiredMsg = "Description cannot be empty!";
        public const string TitleMaxLength = "Title must not contain more than 100 characters!";
        public const string DescriptionMaxLength = "Description must not contain more than 500 characters!";

        public const string UrlSlugRequiredMsg = "URL Slug cannot be empty!";
        public const string UrlSlugMaxLength = "URL Slug length only 100!";
        public const string InvalidUrlSlug = "Invalid URL Slug. Slug can only contain lowercase letters, numbers, and hyphens and must not begin with a number (e.g., 'my-post-123')";
        public const string SlugPattern = @"^[a-z][a-z0-9]*(?:-[a-z0-9]+)*$";

        //Banner validation
        public const int MaxBannerCount = 10;
        public const string IsDisplayed = "Show on HomePage";
    }
}
