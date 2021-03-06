﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Windows.Forms;

namespace BaseLib
{
    public class ChilkatHttpHelpr
    {
        #region variable declaration
        public string proxyAddress = string.Empty;
        public string proxyPort = string.Empty;
        public string proxyUsername = string.Empty;
        public string proxyPassword = string.Empty;

        ///Chilkat Http object...
        Chilkat.Http http = new Chilkat.Http();

        ///Chilkat Http Request to be used in Http Post...
        Chilkat.HttpRequest req = new Chilkat.HttpRequest();
        private Dictionary<string, string> postDataDictionary = new Dictionary<string, string>(); 
        #endregion

        #region ChilkatHttpHelpr
        public ChilkatHttpHelpr()
        {
            if (!http.UnlockComponent("THEBACHttp_b3C9o9QvZQ06"))
            {
            }

            ///Save Cookies...
            http.CookieDir = "memory";
            http.SendCookies = true;
            http.SaveCookies = true;

            http.SetRequestHeader("Accept-Encoding", "gzip,deflate");
            http.SetRequestHeader("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:18.0) Gecko/20100101 Firefox/18.0");
            http.SetRequestHeader("Accept", "application/json,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8, */*");
            http.SetRequestHeader("Connection", "keep-alive");

            http.AllowGzip = true;
        } 
        #endregion

        #region ChangeProxy
        private void ChangeProxy()
        {
            if (!string.IsNullOrEmpty(proxyAddress))
            {
                http.ProxyDomain = "127.0.0.1";//proxyAddress;
                if (!string.IsNullOrEmpty(proxyPort))
                {
                    Regex IdCheck = new Regex("^[0-9]*$");

                    if (!string.IsNullOrEmpty(proxyPort) && IdCheck.IsMatch(proxyPort))
                    {
                        http.ProxyPort = int.Parse("8888");
                    }
                    else
                    {
                        proxyPort = "80";
                        http.ProxyPort = int.Parse(proxyPort);
                    }
                }
                //http.ProxyPort = int.Parse(proxyPort);
            }
            if (!string.IsNullOrEmpty(proxyUsername))
            {
                http.ProxyLogin = proxyUsername;
                http.ProxyPassword = proxyPassword;
            }
        } 
        #endregion

        #region GetHtml
        public string GetHtml(string URL)
        {
            string response = string.Empty;

            ChangeProxy();

            response = http.QuickGetStr(URL);

            return response;
        } 
        #endregion

        #region GetHtml
        public string GetHtml(string URL, string referer)
        {
            string response = string.Empty;

            ChangeProxy();

            ///Set Referer
            if (!string.IsNullOrEmpty(referer))
            {
                req.AddHeader("Referer", referer);
            }

            response = http.QuickGetStr(URL);

            return response;
        } 
        #endregion

        #region GetHtmlProxy
        public string GetHtmlProxy(string URL, string proxyAddress, string proxyPort, string proxyUsername, string proxyPassword)
        {
            string response = string.Empty;

            this.proxyAddress = proxyAddress;
            this.proxyPort = proxyPort;
            this.proxyUsername = proxyUsername;
            this.proxyPassword = proxyPassword;

            ChangeProxy();

            if (!http.UnlockComponent("THEBACHttp_b3C9o9QvZQ06"))
            {
            }


            response = http.QuickGetStr(URL);

            return response;
        } 
        #endregion

        #region GetHtmlProxy
        public string GetHtmlProxy(string URL, string proxyAddress, string proxyPort, string proxyUsername, string proxyPassword, string referer)
        {
            string response = string.Empty;

            this.proxyAddress = proxyAddress;
            this.proxyPort = proxyPort;
            this.proxyUsername = proxyUsername;
            this.proxyPassword = proxyPassword;

            ChangeProxy();

            ///Set Referer
            if (!string.IsNullOrEmpty(referer))
            {
                req.AddHeader("Referer", referer);
            }

            response = http.QuickGetStr(URL);

            return response;
        } 
        #endregion

        #region GetHtmlProxy
        public string GetHtmlProxy(string URL, string proxyAddress, string proxyPort, string proxyUsername, string proxyPassword, ref Chilkat.Http http)
        {
            string response = string.Empty;

            this.proxyAddress = proxyAddress;
            this.proxyPort = proxyPort;
            this.proxyUsername = proxyUsername;
            this.proxyPassword = proxyPassword;

            ChangeProxy();

            response = http.QuickGetStr(URL);

            return response;
        } 
        #endregion

        #region PostData
        public string PostData(string URL, string postData, string referer)
        {
            string response = string.Empty;

            ChangeProxy();

            //http.SetRequestHeader("Cookie", "PREF=ID=39a7dcb4769a70b5:U=01e856263f78e316:FF=0:TM=1310809062:LM=1311756586:GM=1:S=qiyaqpZc0QJwSHyD;NID=49=Ljnrtc5KZDOFfgRVn1Tt6G6MdaeISmX4vOzE7MSbouPD_4ze6OoSuCMWXlH0Jy7fnAlEYzdYxs4V7JP2DXnKgDxVQMKYY60yWoeCgFIwTL2WWBfmxJZNml5pYdudn5Zw;GAPS=1:tS3_AUBl7WpcKSXAXYMVdDiWuMdX0Q:rAR7mbwZ6PlPnJt-;GALX=7iQKVcsEdN4;GoogleAccountsLocale_session=en_GB;SID=DQAAAIUAAAD1r3xd8mtKrnHFMI4AdB1fuFDSG6YQ98V-_olltRKYgRSHMAgKC9eU88xa6oIay8EgmaV8PRZl1uxi_Q7Hx3etXAUCd42mHJph5YHU015yCzmHUoGdeVpzpFtvPc4xFpnu1Hl2PqXSN4tIlDAY_Qg6vs8I8eoWpiVPPXkLR1WaKcw54W9s1Yx1PxN7C5Nazmc;LSID=blogger|s.IN:DQAAAIYAAACEkfAmZiRHYaawY6Ol0Oguk5C58mprkWFDmf4StK2d_UZDRC6baudw3SoGKkQGBEsB4r2wRrklsK9O1XChX7Pj-UnTPMaDxSz4ADM5O69S-LQhLJx10-1kdeomZSC2NIOWxIpHhoWn1FPrpQrFDgisVLfVsHsjD7l5ASyaLzgzaIxx-XZfuQHaCRgnMRF09vo;GAUSR=lachelle.longenecker.jvqq@hotmail.com;HSID=AuAY8LSZuG828am_4;SSID=AYAPgLxKQx6efsNxV;APISID=j799BJ0rwj5vK8S3/Aid730sB7T-6RWKbq;SAPISID=BnxZXhygC3cPGeSV/AVHrAqmtZgl16WiOi");

            req.RemoveAllParams();

            req.UsePost();
            //req.Path = "/login.php?login_attempt=1";

            req.AddHeader("Accept-Encoding", "gzip,deflate");
            req.AddHeader("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:18.0) Gecko/20100101 Firefox/18.0");
            req.AddHeader("Accept", "application/json,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8, */*");
            req.AddHeader("Connection", "keep-alive");

            //req.AddHeader("Cookie", "PREF=ID=39a7dcb4769a70b5:U=01e856263f78e316:FF=0:TM=1310809062:LM=1311756586:GM=1:S=qiyaqpZc0QJwSHyD;NID=49=Ljnrtc5KZDOFfgRVn1Tt6G6MdaeISmX4vOzE7MSbouPD_4ze6OoSuCMWXlH0Jy7fnAlEYzdYxs4V7JP2DXnKgDxVQMKYY60yWoeCgFIwTL2WWBfmxJZNml5pYdudn5Zw;GAPS=1:tS3_AUBl7WpcKSXAXYMVdDiWuMdX0Q:rAR7mbwZ6PlPnJt-;GALX=7iQKVcsEdN4;GoogleAccountsLocale_session=en_GB;SID=DQAAAIUAAAD1r3xd8mtKrnHFMI4AdB1fuFDSG6YQ98V-_olltRKYgRSHMAgKC9eU88xa6oIay8EgmaV8PRZl1uxi_Q7Hx3etXAUCd42mHJph5YHU015yCzmHUoGdeVpzpFtvPc4xFpnu1Hl2PqXSN4tIlDAY_Qg6vs8I8eoWpiVPPXkLR1WaKcw54W9s1Yx1PxN7C5Nazmc;LSID=blogger|s.IN:DQAAAIYAAACEkfAmZiRHYaawY6Ol0Oguk5C58mprkWFDmf4StK2d_UZDRC6baudw3SoGKkQGBEsB4r2wRrklsK9O1XChX7Pj-UnTPMaDxSz4ADM5O69S-LQhLJx10-1kdeomZSC2NIOWxIpHhoWn1FPrpQrFDgisVLfVsHsjD7l5ASyaLzgzaIxx-XZfuQHaCRgnMRF09vo;GAUSR=lachelle.longenecker.jvqq@hotmail.com;HSID=AuAY8LSZuG828am_4;SSID=AYAPgLxKQx6efsNxV;APISID=j799BJ0rwj5vK8S3/Aid730sB7T-6RWKbq;SAPISID=BnxZXhygC3cPGeSV/AVHrAqmtZgl16WiOi");

            #region PostData

            string[] arrPostData = Regex.Split(postData, "&");

            postDataDictionary.Clear();

            foreach (string item in arrPostData)
            {
                try
                {
                    postDataDictionary.Add(item.Split('=')[0], item.Split('=')[1]);
                }
                catch (Exception)
                {
                }
            }

            foreach (var item in postDataDictionary)
            {
                req.AddParam(item.Key, item.Value);
            }

            #endregion

            ///Set Referer
            if (!string.IsNullOrEmpty(referer))
            {
                req.AddHeader("Referer", referer);
            }

            Chilkat.HttpResponse respUsingPostURLEncoded = http.PostUrlEncoded(URL, req);
            string ResponseLoginPostURLEncoded = respUsingPostURLEncoded.BodyStr;

            response = ResponseLoginPostURLEncoded;

            return response;
        } 
        #endregion

        #region PostFormData
        public string PostFormData(string URL, string postData, string referer)
        {
            string response = string.Empty;

            ChangeProxy();

            //http.SetRequestHeader("Cookie", "PREF=ID=39a7dcb4769a70b5:U=01e856263f78e316:FF=0:TM=1310809062:LM=1311756586:GM=1:S=qiyaqpZc0QJwSHyD;NID=49=Ljnrtc5KZDOFfgRVn1Tt6G6MdaeISmX4vOzE7MSbouPD_4ze6OoSuCMWXlH0Jy7fnAlEYzdYxs4V7JP2DXnKgDxVQMKYY60yWoeCgFIwTL2WWBfmxJZNml5pYdudn5Zw;GAPS=1:tS3_AUBl7WpcKSXAXYMVdDiWuMdX0Q:rAR7mbwZ6PlPnJt-;GALX=7iQKVcsEdN4;GoogleAccountsLocale_session=en_GB;SID=DQAAAIUAAAD1r3xd8mtKrnHFMI4AdB1fuFDSG6YQ98V-_olltRKYgRSHMAgKC9eU88xa6oIay8EgmaV8PRZl1uxi_Q7Hx3etXAUCd42mHJph5YHU015yCzmHUoGdeVpzpFtvPc4xFpnu1Hl2PqXSN4tIlDAY_Qg6vs8I8eoWpiVPPXkLR1WaKcw54W9s1Yx1PxN7C5Nazmc;LSID=blogger|s.IN:DQAAAIYAAACEkfAmZiRHYaawY6Ol0Oguk5C58mprkWFDmf4StK2d_UZDRC6baudw3SoGKkQGBEsB4r2wRrklsK9O1XChX7Pj-UnTPMaDxSz4ADM5O69S-LQhLJx10-1kdeomZSC2NIOWxIpHhoWn1FPrpQrFDgisVLfVsHsjD7l5ASyaLzgzaIxx-XZfuQHaCRgnMRF09vo;GAUSR=lachelle.longenecker.jvqq@hotmail.com;HSID=AuAY8LSZuG828am_4;SSID=AYAPgLxKQx6efsNxV;APISID=j799BJ0rwj5vK8S3/Aid730sB7T-6RWKbq;SAPISID=BnxZXhygC3cPGeSV/AVHrAqmtZgl16WiOi");

            req.RemoveAllParams();

            req.UsePost();
            //req.Path = "/login.php?login_attempt=1";

            req.AddHeader("Accept-Encoding", "gzip,deflate");
            req.AddHeader("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            req.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:18.0) Gecko/20100101 Firefox/18.0");
            req.AddHeader("Accept", "application/json,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8, */*");
            req.AddHeader("Connection", "keep-alive");


            //req.AddHeader("Cookie", "PREF=ID=39a7dcb4769a70b5:U=01e856263f78e316:FF=0:TM=1310809062:LM=1311756586:GM=1:S=qiyaqpZc0QJwSHyD;NID=49=Ljnrtc5KZDOFfgRVn1Tt6G6MdaeISmX4vOzE7MSbouPD_4ze6OoSuCMWXlH0Jy7fnAlEYzdYxs4V7JP2DXnKgDxVQMKYY60yWoeCgFIwTL2WWBfmxJZNml5pYdudn5Zw;GAPS=1:tS3_AUBl7WpcKSXAXYMVdDiWuMdX0Q:rAR7mbwZ6PlPnJt-;GALX=7iQKVcsEdN4;GoogleAccountsLocale_session=en_GB;SID=DQAAAIUAAAD1r3xd8mtKrnHFMI4AdB1fuFDSG6YQ98V-_olltRKYgRSHMAgKC9eU88xa6oIay8EgmaV8PRZl1uxi_Q7Hx3etXAUCd42mHJph5YHU015yCzmHUoGdeVpzpFtvPc4xFpnu1Hl2PqXSN4tIlDAY_Qg6vs8I8eoWpiVPPXkLR1WaKcw54W9s1Yx1PxN7C5Nazmc;LSID=blogger|s.IN:DQAAAIYAAACEkfAmZiRHYaawY6Ol0Oguk5C58mprkWFDmf4StK2d_UZDRC6baudw3SoGKkQGBEsB4r2wRrklsK9O1XChX7Pj-UnTPMaDxSz4ADM5O69S-LQhLJx10-1kdeomZSC2NIOWxIpHhoWn1FPrpQrFDgisVLfVsHsjD7l5ASyaLzgzaIxx-XZfuQHaCRgnMRF09vo;GAUSR=lachelle.longenecker.jvqq@hotmail.com;HSID=AuAY8LSZuG828am_4;SSID=AYAPgLxKQx6efsNxV;APISID=j799BJ0rwj5vK8S3/Aid730sB7T-6RWKbq;SAPISID=BnxZXhygC3cPGeSV/AVHrAqmtZgl16WiOi");

            #region PostData

            string[] arrPostData = Regex.Split(postData, "&");

            postDataDictionary.Clear();

            foreach (string item in arrPostData)
            {
                try
                {
                    postDataDictionary.Add(item.Split('=')[0], item.Split('=')[1]);
                }
                catch (Exception)
                {
                }
            }

            foreach (var item in postDataDictionary)
            {
                req.AddParam(item.Key, item.Value);
            }

            #endregion

            ///Set Referer
            if (!string.IsNullOrEmpty(referer))
            {
                req.AddHeader("Referer", referer);
            }

            Chilkat.HttpResponse respUsingPostURLEncoded = http.PostUrlEncoded(URL, req);
            string ResponseLoginPostURLEncoded = respUsingPostURLEncoded.BodyStr;

            response = ResponseLoginPostURLEncoded;

            return response;
        } 
        #endregion

        #region ConvertHtmlToXml
        public string ConvertHtmlToXml(string PageSrcHtml)
        {
            ////  Convert the HTML to XML:
            bool success = false;
            string xHtml = string.Empty;

            Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();
            success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
            if ((success != true))
            {
                Console.WriteLine(htmlToXml.LastErrorText);
                return null;
            }

            htmlToXml.Html = PageSrcHtml;

            //xHtml contain xml data 
            xHtml = htmlToXml.ToXml();

            Chilkat.Xml xml = new Chilkat.Xml();
            xml.LoadXml(xHtml);
            //xHtml.
            return xHtml;
        } 
        #endregion

        #region GetDataTag
        public List<string> GetDataTag(string pageSrcHtml, string TagName)
        {
            bool success = false;
            string xHtml = string.Empty;
            List<string> list = new List<string>();



            Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();
            success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
            if ((success != true))
            {
                Console.WriteLine(htmlToXml.LastErrorText);
                return null;
            }

            htmlToXml.Html = pageSrcHtml;

            //xHtml contain xml data 
            xHtml = htmlToXml.ToXml();

            //******************************************
            Chilkat.Xml xNode = default(Chilkat.Xml);
            Chilkat.Xml xBeginSearchAfter = default(Chilkat.Xml);
            Chilkat.Xml xml = new Chilkat.Xml();
            xml.LoadXml(xHtml);

            xBeginSearchAfter = null;
            xNode = xml.SearchForTag(xBeginSearchAfter, TagName);
            while ((xNode != null))
            {

                string TagText = xNode.AccumulateTagContent("text", "script|style");

                list.Add(TagText);

                xBeginSearchAfter = xNode;
                xNode = xml.SearchForTag(xBeginSearchAfter, TagName);

            }
            //xHtml.
            return list;
        } 
        #endregion

        #region GetDataTagAttribute
        public List<string> GetDataTagAttribute(string pageSrcHtml, string TagName, string AttributeName)
        {
            List<string> lstData = new List<string>();
            try
            {
                bool success = false;
                string xHtml = string.Empty;

                Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();

                //*** Check DLL working or not **********************
                success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
                if ((success != true))
                {
                    Console.WriteLine(htmlToXml.LastErrorText);
                    return null;
                }

                htmlToXml.Html = pageSrcHtml;

                //** Convert Data Html to XML ******************************************* 
                xHtml = htmlToXml.ToXml();

                //******************************************
                Chilkat.Xml xNode = default(Chilkat.Xml);
                Chilkat.Xml xBeginSearchAfter = default(Chilkat.Xml);
                Chilkat.Xml xml = new Chilkat.Xml();
                xml.LoadXml(xHtml);

                #region Data Save in list From using XML Tag and Attribut
                string DescriptionMain = string.Empty;
                string dataDescription = string.Empty;

                xBeginSearchAfter = null;

                xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "class", AttributeName);
                while ((xNode != null))
                {
                    //** Get Data Under Tag only Text Value**********************************
                    dataDescription = xNode.AccumulateTagContent("text", "script|style");
                    lstData.Add(dataDescription);

                    //** Get Data Under Tag All  Html value * *********************************
                    //dataDescription = xNode.GetXml();
                    xBeginSearchAfter = xNode;
                    xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "class", AttributeName);
                }
                #endregion
                return lstData;
            }
            catch (Exception)
            {
                return lstData = null;

            }
        } 
        #endregion

        #region GetDataTagAttributewithId
        public List<string> GetDataTagAttributewithId(string pageSrcHtml, string TagName, string AttributeName)
        {
            List<string> lstData = new List<string>();
            try
            {
                bool success = false;
                string xHtml = string.Empty;

                Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();

                //*** Check DLL working or not **********************
                success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
                if ((success != true))
                {
                    Console.WriteLine(htmlToXml.LastErrorText);
                    return null;
                }

                htmlToXml.Html = pageSrcHtml;

                //** Convert Data Html to XML ******************************************* 
                xHtml = htmlToXml.ToXml();

                //******************************************
                Chilkat.Xml xNode = default(Chilkat.Xml);
                Chilkat.Xml xBeginSearchAfter = default(Chilkat.Xml);
                Chilkat.Xml xml = new Chilkat.Xml();
                xml.LoadXml(xHtml);

                #region Data Save in list From using XML Tag and Attribut
                string DescriptionMain = string.Empty;
                string dataDescription = string.Empty;

                xBeginSearchAfter = null;

                xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "id", AttributeName);
                while ((xNode != null))
                {
                    //** Get Data Under Tag only Text Value**********************************
                    dataDescription = xNode.AccumulateTagContent("text", "script|style");
                    lstData.Add(dataDescription);

                    //** Get Data Under Tag All  Html value * *********************************
                    //dataDescription = xNode.GetXml();
                    xBeginSearchAfter = xNode;
                    xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "id", AttributeName);
                }
                #endregion
                return lstData;
            }
            catch (Exception)
            {
                return lstData = null;

            }
        } 
        #endregion

        #region GetTitle
        public string GetTitle(string HtmlPageSrc)
        {
            Chilkat.HtmlUtil obj = new Chilkat.HtmlUtil();
            string Title = obj.GetTitle(HtmlPageSrc);
            return Title;
        } 
        #endregion

        #region GetHrefFromString
        public List<string> GetHrefFromString(string pageSrcHtml)
        {
            Chilkat.HtmlUtil obj = new Chilkat.HtmlUtil();

            Chilkat.StringArray dataImage = obj.GetHyperlinkedUrls(pageSrcHtml);

            List<string> list = new List<string>();

            for (int i = 0; i < dataImage.Length; i++)
            {
                string hreflink = dataImage.GetString(i);
                list.Add(hreflink);

            }
            return list;
        } 
        #endregion

        // By Ajay At 08-12-12
        #region GetDataWithTagValueByTagAndAttributeName
        public string GetDataWithTagValueByTagAndAttributeName(string pageSrcHtml, string TagName, string AttributeName)
        {
            string dataDescription = string.Empty;
            try
            {
                bool success = false;
                string xHtml = string.Empty;

                Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();

                //*** Check DLL working or not **********************
                success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
                if ((success != true))
                {
                    Console.WriteLine(htmlToXml.LastErrorText);
                    return null;
                }

                htmlToXml.Html = pageSrcHtml;

                //** Convert Data Html to XML ******************************************* 
                xHtml = htmlToXml.ToXml();

                //******************************************
                Chilkat.Xml xNode = default(Chilkat.Xml);
                Chilkat.Xml xBeginSearchAfter = default(Chilkat.Xml);
                Chilkat.Xml xml = new Chilkat.Xml();
                xml.LoadXml(xHtml);

                #region Data Save in list From using XML Tag and Attribut
                string DescriptionMain = string.Empty;

                string dataDescriptionValue = string.Empty;


                xBeginSearchAfter = null;

                xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "class", AttributeName);
                while ((xNode != null))
                {
                    //** Get Data Under Tag only Text Value**********************************



                    dataDescription = xNode.GetXml();//.AccumulateTagContent("text", "script|style");

                    dataDescriptionValue = dataDescriptionValue + dataDescription;
                    //    string text = xNode.AccumulateTagContent("text", "script|style");
                    //    lstData.Add(text);

                    //    //** Get Data Under Tag All  Html value * *********************************
                    //    //dataDescription = xNode.GetXml();

                    xBeginSearchAfter = xNode;
                    xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "class", AttributeName);
                    //if (dataDescription.Length > 500)
                    //{
                    //    break;
                    //}
                }
                #endregion
                return dataDescriptionValue;
            }
            catch (Exception)
            {
                return dataDescription = null;

            }
        } 
        #endregion

        // By Ajay at 08-12-12
        #region GetDataWithTagValueByTagAndAttributeId
        public string GetDataWithTagValueByTagAndAttributeId(string pageSrcHtml, string TagName, string AttributeName)
        {
            string dataDescription = string.Empty;
            try
            {
                bool success = false;
                string xHtml = string.Empty;

                Chilkat.HtmlToXml htmlToXml = new Chilkat.HtmlToXml();

                //*** Check DLL working or not **********************
                success = htmlToXml.UnlockComponent("THEBACHtmlToXml_7WY3A57sZH3O");
                if ((success != true))
                {
                    Console.WriteLine(htmlToXml.LastErrorText);
                    return null;
                }

                htmlToXml.Html = pageSrcHtml;

                //** Convert Data Html to XML ******************************************* 
                xHtml = htmlToXml.ToXml();

                //******************************************
                Chilkat.Xml xNode = default(Chilkat.Xml);
                Chilkat.Xml xBeginSearchAfter = default(Chilkat.Xml);
                Chilkat.Xml xml = new Chilkat.Xml();
                xml.LoadXml(xHtml);

                #region Data Save in list From using XML Tag and Attribut
                string DescriptionMain = string.Empty;

                string dataDescriptionValue = string.Empty;


                xBeginSearchAfter = null;

                xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "id", AttributeName);
                while ((xNode != null))
                {
                    //** Get Data Under Tag only Text Value**********************************



                    dataDescription = xNode.GetXml();//.AccumulateTagContent("text", "script|style");

                    dataDescriptionValue = dataDescriptionValue + dataDescription;
                    //    string text = xNode.AccumulateTagContent("text", "script|style");
                    //    lstData.Add(text);

                    //    //** Get Data Under Tag All  Html value * *********************************
                    //    //dataDescription = xNode.GetXml();

                    xBeginSearchAfter = xNode;
                    xNode = xml.SearchForAttribute(xBeginSearchAfter, TagName, "id", AttributeName);
                    //if (dataDescription.Length > 500)
                    //{
                    //    break;
                    //}
                }
                #endregion
                return dataDescriptionValue;
            }
            catch (Exception)
            {
                return dataDescription = null;

            }
        } 
        #endregion

    }
}
