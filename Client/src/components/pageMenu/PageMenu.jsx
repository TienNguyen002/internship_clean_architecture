import React from 'react'
import "./pageMenu.css"
import { useTranslation } from 'react-i18next';

function PageMenu() {
  const { t: translate } = useTranslation();

  return (
      <div>
        <ul data-menu="home" className="menu">
          <li className="menu-part current">
            <a href="/" rel="home">
              <u>{translate('menu.Home')}</u>
            </a>
          </li>
          <li className="menu-part">
            <a href="/about-us/" rel="about-us" className="sub-menu-title">
              {translate('menu.ABOUT US')}
            </a>
            <ul className="sub-menu">
              <li>
                <a href="/about-us/" rel="about-us overview">
                  {translate('menu.Who we are?')}
                </a>
              </li>
              <li>
                <a href="/customers/" rel="customers">
                 {translate('menu.Our Clients')}
                </a>
              </li>
              <li>
                <a href="/news/" rel="news">
                  {translate('menu.News & Events')}
                </a>
              </li>
              <li>
                <a href="blogs" target="_blog_titan">
                  {translate('menu.Blogs')}
                </a>
              </li>
            </ul>
          </li>
          <li className="menu-part">
            <a href="/services/" rel="services">
              {translate('menu.Services')}
              <span className="caret"></span>
            </a>
            <ul className="sub-menu">
              <li>
                <a href="/services/domains/" rel="domains">
                  {translate('menu.Domains & Technologies')}
                </a>
              </li>
              <li>
                <a href="/services/models/" rel="models">
                  {translate('menu.Engagement Models')}
                </a>
              </li>
            </ul>
          </li>
          <li className="menu-part">
            <a href="/innovations/" rel="innovations">
              {translate('menu.Innovations')}
            </a>
          </li>
          <li className="menu-part">
            <a href="/careers/" rel="careers">
              {translate('menu.Careers')}
            </a>
          </li>
          <li className="menu-part">
            <a href="/contact-us/" rel="contact-us">
              {translate('menu.Contact')}
            </a>
          </li>
        </ul>
      </div>
    );
}

export default PageMenu
