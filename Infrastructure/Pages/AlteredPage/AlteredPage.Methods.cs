﻿using OpenQA.Selenium;

namespace Infrastructure.Pages
{
    public abstract partial class AlteredPage : BasePage
    {
        protected AlteredPage(IWebDriver driver) : base(driver) { }

        public HeaderSection Header => new HeaderSection(Driver);
    }
}
